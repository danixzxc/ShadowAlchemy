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
    public override void CastSkill(float direction, GameObject player)
    {
        Debug.Log("Skastoval");
        _time = _characteristics.dashDistance / _characteristics.dashVelocity;
        _rigidbody = player.GetComponent<Rigidbody2D>();
        var coroutine = WaitForSkillEnd(direction);
        player.GetComponent<PlayerMovement>().StartCoroutine(coroutine); // Evil MonoBehaviour Hack.
    }

    private IEnumerator WaitForSkillEnd(float direction)
    {
        float time = 0;
        while (time < _time)
        {
            _rigidbody.velocity = AngleToVec2(direction) * _characteristics.dashVelocity;
            yield return new WaitForFixedUpdate();
            time += Time.fixedDeltaTime;
        }
        _rigidbody.velocity = _rigidbody.velocity / _characteristics.finalVelocityPercent * 100;
    }

}
