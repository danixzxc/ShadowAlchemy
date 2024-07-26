using UnityEngine;

public abstract class Skill 
{
    public SkillData data;
    protected Vector2 AngleToVec2(float angle)
    {
        return new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
    }
    public abstract void castSkill(float direction, GameObject player);
}
