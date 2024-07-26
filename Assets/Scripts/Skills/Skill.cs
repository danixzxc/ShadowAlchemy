using UnityEngine;

public abstract class Skill 
{
    public abstract SkillData data { get; set; }

    public abstract void castSkill(float direction, GameObject player);
}
