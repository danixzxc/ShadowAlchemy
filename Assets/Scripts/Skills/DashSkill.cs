using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill :  Skill
{
    private SkillsCharacteristics _characteristics;

    private Rigidbody2D _rigidbody;
    private float _time;
    private IEnumerator coroutine;
    public DashSkill()
    {
        data = CombinationManager.Instance.GetSkillData("dash");
        _characteristics = CombinationManager.Instance.GetSkillsCharacteristics();
        //Debug.Log("I know characteristics" + _characteristics.dashVelocity);
    }

    public override bool CanCast(GameObject player) {
        return player.GetComponent<PlayerMana>().Mana > data.cost && player.GetComponent<PlayerMovement>().IsGrounded();
    }

    public override void CastSkill(float direction, GameObject player)
    {
        if (!CanCast(player)){ return; }
        _time = _characteristics.dashDistance / _characteristics.dashVelocity;
        _rigidbody = player.GetComponent<Rigidbody2D>();
        player.GetComponent<PlayerMana>().Mana -= data.cost;
        var coroutine = WaitForSkillEnd(player);
        player.GetComponent<PlayerMovement>().StartCoroutine(coroutine); // Evil MonoBehaviour Hack.
        
    }

   

    private IEnumerator WaitForSkillEnd(GameObject player)
    {
        player.GetComponent<ButtonPresser>().CanPress = false;
        float time = 0;
        while (time < _time)
        {
            _rigidbody.velocity = Vector2.right * _characteristics.dashVelocity;
            yield return new WaitForFixedUpdate();
            time += Time.fixedDeltaTime;
        }
        _rigidbody.velocity = _rigidbody.velocity * _characteristics.dashFinalVelocityPercent / 100;
        player.GetComponent<ButtonPresser>().CanPress = true;
    }

}
