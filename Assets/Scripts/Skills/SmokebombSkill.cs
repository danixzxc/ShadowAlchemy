using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBombSkill : Skill
{
    private SkillsCharacteristics _characteristics;
    private GameObject projectile;

    public SmokeBombSkill()
    {
        data = CombinationManager.Instance.GetSkillData("Smoke!");
        _characteristics = CombinationManager.Instance.GetSkillsCharacteristics();
        projectile = _characteristics.smokeBombPrefab; //smokeInvisTime
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
        var thing = Object.Instantiate(projectile, player.transform.position + new Vector3(0.3f, 1.0f, 0.0f), Quaternion.identity);
        thing.GetComponent<Rigidbody2D>().angularVelocity = 720f;
        thing.GetComponent<Rigidbody2D>().velocity = AngleToVec2(angle) * player.GetComponent<Rigidbody2D>().velocity * 1.4f;
        player.GetComponent<SpritesTransparentMaker>().transparent = true;
        player.GetComponent<PlayerDeath>().ImmuneTo.Add(DamageType.Samurai);
        player.GetComponent<Rigidbody2D>().excludeLayers |= LayerMask.GetMask("Enemy");
        yield return new WaitForSeconds(_characteristics.smokeInvisTime);
        player.GetComponent<Rigidbody2D>().excludeLayers &= ~LayerMask.GetMask("Enemy");
        Object.Destroy(thing, 2.0f); 
        player.GetComponent<PlayerDeath>().ImmuneTo.Remove(DamageType.Samurai);
        player.GetComponent<SpritesTransparentMaker>().transparent = false;
    }
}
