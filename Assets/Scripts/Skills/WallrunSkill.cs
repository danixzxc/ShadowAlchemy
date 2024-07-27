using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class WallrunSkill :  Skill
{
    private SkillsCharacteristics _characteristics;
    private bool skillCanceled;
    private bool hasJumped = false;
    public WallrunSkill()
    {
        data = CombinationManager.Instance.GetSkillData("wallrun");
        _characteristics = CombinationManager.Instance.GetSkillsCharacteristics();
    }

    public override bool CanCast(GameObject player) {
        return player.GetComponent<PlayerMana>().Mana > data.cost &&
            player.GetComponent<PlayerWallrunSensor>().GetWallrunAreaIntersection() && !hasJumped; 
    }


    public override void CastSkill(float direction, GameObject player)
    {
        if (!CanCast(player)){ return; }
        skillCanceled = false;
        player.GetComponent<PlayerMana>().Mana -= data.cost;
        var playerMovement = player.GetComponent<PlayerMovement>();
        var rigidbody = player.GetComponent<Rigidbody2D>();
        var playerWallrunSensor = player.GetComponent<PlayerWallrunSensor>();
        var coroutine = WaitForSkillEnd(playerMovement, rigidbody, playerWallrunSensor, player.GetComponent<Animator>());
        playerMovement.StartCoroutine(coroutine);
    }

    
    public override void Cancel()
    {
        skillCanceled = true;
    }
    private IEnumerator WaitForSkillEnd(PlayerMovement playerMovement, Rigidbody2D rigidbody, PlayerWallrunSensor playerWallrunSensor, Animator animator)
    {
        animator.ResetTrigger("EndSkill");
        animator.SetTrigger("ToWallrun");
        hasJumped = true;
        rigidbody.velocity = AngleToVec2(_characteristics.wallrunAngle)
            * rigidbody.velocity.magnitude * _characteristics.wallrunDistance;

        while (!playerMovement.TouchingWall() && playerWallrunSensor.GetWallrunAreaIntersection() && !skillCanceled) 
        {
            yield return new WaitForFixedUpdate();
        }
        rigidbody.velocity = new Vector2(rigidbody.velocity.x / 100 * _characteristics.wallrunFinalVelocityPercent, -0.3f);
        while (!playerMovement.IsGrounded()) 
        {
            yield return new WaitForFixedUpdate();
        }
        hasJumped = false;
        animator.SetTrigger("EndSkill");
        
    }



}
