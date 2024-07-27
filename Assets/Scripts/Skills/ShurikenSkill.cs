using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenSkill : Skill
{
    private SkillsCharacteristics _characteristics;
    private GameObject projectile;

    public ShurikenSkill()
    {
        data = CombinationManager.Instance.GetSkillData("shuriken");
        _characteristics = CombinationManager.Instance.GetSkillsCharacteristics();
        projectile = _characteristics.shurikenPrefab;
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
        var thing = Object.Instantiate(projectile, player.transform.position + new Vector3(0.3f, 1.0f, 0.0f), Quaternion.identity);
        thing.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        thing.GetComponent<Rigidbody2D>().velocity = AngleToVec2(angle) * _characteristics.shurikenSpeed;
        thing.GetComponent<DamageDealer>().damage = _characteristics.shurikenDamage;
        yield return new WaitForFixedUpdate();
    }
}
