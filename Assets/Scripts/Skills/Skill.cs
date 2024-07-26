using UnityEngine;

public abstract class Skill 
{
    public SkillData data; 

    public abstract void castSkill(float direction, GameObject player);
}
