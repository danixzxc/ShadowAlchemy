using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallrunSkill :  Skill
{
    private SkillsCharacteristics _characteristics;
   
    public WallrunSkill()
    {
        data = CombinationManager.Instance.GetSkillData("wallrun");
        _characteristics = CombinationManager.Instance.GetSkillsCharacteristics();
    }

    public override bool CanCast(GameObject player) {
        return player.GetComponent<PlayerMana>().Mana > data.cost &&
            player.GetComponent<PlayerWallrunSensor>().GetWallrunAreaIntersection(); 
    }


    public override void CastSkill(float direction, GameObject player)
    {
        if (!CanCast(player)){ return; }
        Debug.Log($"I am wallruning!!! info: {_characteristics.wallrunFinalVelocityPercent}");
    }

    //cancel skill

   

}
