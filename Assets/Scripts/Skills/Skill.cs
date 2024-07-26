using UnityEngine;

public class Skill 
{
    public SkillData data;
    public Skill()
    {
        data = CombinationManager.Instance.GetSkillData("None");
    }
    protected Vector2 AngleToVec2(float angle)
    {
        return new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
    }
    public virtual void CastSkill(float direction, GameObject player) { }

    public virtual bool CanCast(GameObject player) {
        return player.GetComponent<PlayerMana>().Mana > data.cost;
    }

    public virtual void Cancel(){}
    
}
