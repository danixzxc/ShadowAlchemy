using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningAttackSkill :  Skill
{
    private SkillsCharacteristics _characteristics;

    private Rigidbody2D _rigidbody;
    private float _dashtime;
    private GameObject _hitbox;
    public SpinningAttackSkill()
    {
        data = CombinationManager.Instance.GetSkillData("spinningAttack");
        _characteristics = CombinationManager.Instance.GetSkillsCharacteristics();
        _hitbox = _characteristics.spinningAttackHitbox;
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
        player.GetComponent<Animator>().SetTrigger("ToSpin"); 
        player.GetComponent<ButtonPresser>().CanPress = false;
        float time = 0;
        var hitbox = Object.Instantiate(_hitbox, player.transform.position + new Vector3(0f, .9f, 0.0f), Quaternion.identity);
        hitbox.GetComponent<DamageDealer>().damage = _characteristics.spinningAttackDamage;
        hitbox.transform.SetParent(player.transform);
        player.GetComponent<PlayerDeath>().ImmuneTo.Add(DamageType.Samurai);
        while (time < _dashtime)
        {
            _rigidbody.velocity = Vector2.right * _characteristics.spinningAttackVelocity;
            yield return new WaitForFixedUpdate();
            time += Time.fixedDeltaTime;
        }
        player.GetComponent<PlayerDeath>().ImmuneTo.Remove(DamageType.Samurai);
        _rigidbody.velocity = _rigidbody.velocity * _characteristics.spinningAttackFinalVelocityPercent / 100;
        player.GetComponent<ButtonPresser>().CanPress = true;
        player.GetComponent<Animator>().SetTrigger("EndSkill");
    }

}
