using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackstepSkill :  Skill
{
    private SkillsCharacteristics _characteristics;

    private Rigidbody2D _rigidbody;
    private float _time;
    public BackstepSkill()
    {
        data = CombinationManager.Instance.GetSkillData("backstep");
        _characteristics = CombinationManager.Instance.GetSkillsCharacteristics();
    }

    public override bool CanCast(GameObject player) {
        return player.GetComponent<PlayerMana>().Mana > data.cost && player.GetComponent<PlayerMovement>().IsGrounded();
    }

    public override void CastSkill(float direction, GameObject player)
    {
        if (!CanCast(player)){ return; }
        _time = _characteristics.backstepDistance / _characteristics.backstepVelocity;
        _rigidbody = player.GetComponent<Rigidbody2D>();
        player.GetComponent<PlayerMana>().Mana -= data.cost;
        var coroutine = WaitForSkillEnd();
        player.GetComponent<PlayerMovement>().StartCoroutine(coroutine); // Evil MonoBehaviour Hack.
        
    }

   

    private IEnumerator WaitForSkillEnd()
    {
        float time = 0;
        while (time < _time)
        {
            _rigidbody.velocity = Vector2.left * _characteristics.backstepVelocity;
            yield return new WaitForFixedUpdate();
            time += Time.fixedDeltaTime;
        }
        _rigidbody.velocity = -1 * _rigidbody.velocity * _characteristics.backstepFinalVelocityPercent / 100;
    }

}
