using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSkill :  Skill
{
    private SkillsCharacteristics _characteristics;

    private Rigidbody2D _rigidbody;
    private float _time;
    public JumpSkill()
    {
        data = CombinationManager.Instance.GetSkillData("jump");
        _characteristics = CombinationManager.Instance.GetSkillsCharacteristics();
    }

    public override bool CanCast(GameObject player) {
        return player.GetComponent<PlayerMana>().Mana > data.cost && player.GetComponent<PlayerMovement>().IsGrounded();
    }

    public override void CastSkill(float direction, GameObject player)
    {
        if (!CanCast(player)){ return; }
        _rigidbody = player.GetComponent<Rigidbody2D>();
        player.GetComponent<PlayerMana>().Mana -= data.cost;
        var coroutine = SkillCoroutine(player, direction);
        player.GetComponent<PlayerMovement>().StartCoroutine(coroutine); // Evil MonoBehaviour Hack.
        //playerMovement.ChangeVerticalState(playerMovement.jumpingState); 
        
    }

    private IEnumerator SkillCoroutine(GameObject player, float angle)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        _rigidbody.velocity = AngleToVec2(angle) * _characteristics.jumpVelocity;
        playerMovement.ChangeVerticalState(playerMovement.jumpingState);
        while (_rigidbody.velocity.y > 0.0f)
        {
            yield return new WaitForFixedUpdate();
        }
        Vector2 lastVelocity = Vector2.zero;
        while (!playerMovement.IsInVerticalState(playerMovement.onGroundState))
        {
            lastVelocity = _rigidbody.velocity;
            yield return new WaitForFixedUpdate();
        }
        _rigidbody.velocity = Vector2.right * lastVelocity.magnitude * _characteristics.landingMultiplier;

    }
}

