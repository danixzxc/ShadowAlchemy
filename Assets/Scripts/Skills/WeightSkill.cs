using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightSkill : Skill
{
    private SkillsCharacteristics _characteristics;
    private GameObject projectile;

    public WeightSkill()
    {
        data = CombinationManager.Instance.GetSkillData("Weight bombing!");
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
        player.GetComponent<Animator>().ResetTrigger("EndSkill");
        player.GetComponent<Animator>().SetTrigger("Throw");
        yield return new WaitForSeconds(0.15f);
        var thing = Object.Instantiate(projectile, player.transform.position + new Vector3(1.0f, 1.0f, 0.0f), Quaternion.identity);
        thing.GetComponent<Rigidbody2D>().gravityScale = _characteristics.weightGravityMultiplier;
        thing.GetComponent<MovingDamageDealer>().damage = _characteristics.weightDamage;
        thing.GetComponent<MovingDamageDealer>().minimalVelocity = _characteristics.weightMinimalVelocity;
        yield return new WaitForFixedUpdate();
    }
}
