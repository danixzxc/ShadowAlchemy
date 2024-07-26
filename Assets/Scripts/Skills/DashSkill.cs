using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill :  Skill
{

    [SerializeField]
    private float _velocity;
    [SerializeField]
    private float _distance;
    [SerializeField]
    private float _finalVelocity;

    private Rigidbody2D _rigidbody;
    private float _time;
    public DashSkill()
    {
        //data = CombinationManager.Instance.
    }
    public override void castSkill(float direction, GameObject player)
    {
        _time = _distance/_velocity;
        Rigidbody2D rigidbody = player.GetComponent<Rigidbody2D>();
        WaitForSkillEnd(direction);
    }

    private IEnumerator WaitForSkillEnd(float direction)
    {
        float time = 0;
        while (time < _time)
        {
            _rigidbody.velocity = AngleToVec2(direction) * _velocity;
            yield return new WaitForFixedUpdate();
            time += Time.fixedDeltaTime;
        }
        _rigidbody.velocity = _rigidbody.velocity / _finalVelocity;
    }

}
