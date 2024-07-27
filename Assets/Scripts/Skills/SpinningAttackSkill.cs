using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningAttackSkill :  Skill
{
    private SkillsCharacteristics _characteristics;

    private Rigidbody2D _rigidbody;
    private float _dashtime;
    public SpinningAttackSkill()
    {
        data = CombinationManager.Instance.GetSkillData("spinningAttack");
        _characteristics = CombinationManager.Instance.GetSkillsCharacteristics();
    }

    public override bool CanCast(GameObject player) {
        return player.GetComponent<PlayerMana>().Mana > data.cost && player.GetComponent<PlayerMovement>().IsGrounded();
    }

    public override void CastSkill(float direction, GameObject player)
    {
        if (!CanCast(player)){ return; }
        player.GetComponent<PlayerMana>().Mana -= data.cost;
        _dashtime = _characteristics.spinningAttackDistance / _characteristics.spinningAttackVelocity;
        _rigidbody = player.GetComponent<Rigidbody2D>();
        var coroutine = WaitForSkillEnd(player);
        player.GetComponent<PlayerMovement>().StartCoroutine(coroutine); // Evil MonoBehaviour Hack.
        
    }

   

    private IEnumerator WaitForSkillEnd(GameObject player)
    {
        player.GetComponent<Animator>().ResetTrigger("EndSkill");
        player.GetComponent<Animator>().SetTrigger("ToDash"); // Trigger("ToSpinningAttack")
        player.GetComponent<ButtonPresser>().CanPress = false;
        float time = 0;
        //включить неу€звимость
        //врем€ на атаку всегда меньше или равна общему времени
        while (time < _characteristics.spinningAttackDuration)
        {
        //наносить урон с сопр€женными коллайдерами
            _rigidbody.velocity = Vector2.right * _characteristics.spinningAttackVelocity;
            yield return new WaitForFixedUpdate();
            time += Time.fixedDeltaTime;
        }
        //выключить неу€звимость
        while (time < _dashtime)
        {
            _rigidbody.velocity = Vector2.right * _characteristics.spinningAttackVelocity;
            yield return new WaitForFixedUpdate();
            time += Time.fixedDeltaTime;
        }
        _rigidbody.velocity = _rigidbody.velocity * _characteristics.spinningAttackFinalVelocityPercent / 100;
        player.GetComponent<ButtonPresser>().CanPress = true;
        player.GetComponent<Animator>().SetTrigger("EndSkill");
    }

}
