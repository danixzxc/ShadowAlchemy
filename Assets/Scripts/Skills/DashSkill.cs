using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill :  Skill
{
    public DashSkill()
    {
        //data = CombinationManager.Instance.
    }
    public override void castSkill(float direction, GameObject player)
    {
        Debug.Log("dash casted");
    }
}
