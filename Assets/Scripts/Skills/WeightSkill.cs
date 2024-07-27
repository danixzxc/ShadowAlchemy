using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightSkill : Skill
{
    private SkillsCharacteristics _characteristics;
    private GameObject projectile;

    public WeightSkill()
    {
        data = CombinationManager.Instance.GetSkillData("weight");
        _characteristics = CombinationManager.Instance.GetSkillsCharacteristics();
        projectile = _characteristics.weightPrefab;
    }

    public override void CastSkill(float direction, GameObject player)
    {
        if (!CanCast(player)){ return; }
       
        player.GetComponent<PlayerMana>().Mana -= data.cost;

        var coroutine = SkillCoroutine(player, direction);
        player.GetComponent<PlayerMovement>().StartCoroutine(coroutine); // Evil MonoBehaviour Hack.
        
        
    }

    private IEnumerator SkillCoroutine(GameObject player, float angle)
    {
        Object.Instantiate(projectile, new Vector3(1.0f, 1.0f, 0.0f), Quaternion.identity);
        yield return new WaitForFixedUpdate();
    }
}
