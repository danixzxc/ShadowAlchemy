using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallrunSkill :  Skill
{
    private SkillsCharacteristics _characteristics;
    private bool skillCanceled;
    private bool hasWallRunned = false;
    public WallrunSkill()
    {
        data = CombinationManager.Instance.GetSkillData("Wall Run!");
        _characteristics = CombinationManager.Instance.GetSkillsCharacteristics();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override bool CanCast(GameObject player) {
        return player.GetComponent<PlayerMana>().Mana > data.cost &&
            player.GetComponent<PlayerWallrunSensor>().GetWallrunAreaIntersection() && !hasWallRunned; 
    }


    public override void CastSkill(float direction, GameObject player)
    {
        if (!CanCast(player)){ return; }
        skillCanceled = false;
        player.GetComponent<PlayerMana>().Mana -= data.cost;
        var playerMovement = player.GetComponent<PlayerMovement>();
        var rigidbody = player.GetComponent<Rigidbody2D>();
        var playerWallrunSensor = player.GetComponent<PlayerWallrunSensor>();
        var collider = player.GetComponent<BoxCollider2D>();
        var coroutine = WaitForSkillEnd(playerMovement, rigidbody, playerWallrunSensor, player.GetComponent<Animator>(), collider);
        playerMovement.StartCoroutine(coroutine);
    }

    
    public override void Cancel()
    {
        skillCanceled = true;
    }
    private IEnumerator WaitForSkillEnd(PlayerMovement playerMovement, Rigidbody2D rigidbody, PlayerWallrunSensor playerWallrunSensor, Animator animator, BoxCollider2D collider)
    {
        animator.ResetTrigger("EndSkill");
        animator.SetTrigger("ToWallrun");
        collider.size = new Vector2(collider.size.x, 1);
        hasWallRunned = true;
        rigidbody.velocity = AngleToVec2(_characteristics.wallrunAngle)
            * rigidbody.velocity.magnitude * _characteristics.wallrunDistance;

        while (!playerMovement.TouchingWall() && playerWallrunSensor.GetWallrunAreaIntersection() && !skillCanceled) 
        {
            yield return new WaitForFixedUpdate();
        }
        rigidbody.velocity = new Vector2(rigidbody.velocity.x / 100 * _characteristics.wallrunFinalVelocityPercent, -0.3f);
        collider.size = new Vector2(collider.size.x, 2);
        animator.SetTrigger("EndSkill");
        while (!playerMovement.IsGrounded()) 
        {
            yield return new WaitForFixedUpdate();
        }
        hasWallRunned = false;
        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        hasWallRunned = false;
    }

}
