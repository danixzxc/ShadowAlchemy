using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrySkill :  Skill
{
    private SkillsCharacteristics _characteristics;

    public ParrySkill()
    {
        data = CombinationManager.Instance.GetSkillData("parry");
        _characteristics = CombinationManager.Instance.GetSkillsCharacteristics();
    }

    public override bool CanCast(GameObject player) {
        return player.GetComponent<PlayerMana>().Mana > data.cost; // && player.GetComponent<PlayerMovement>().IsGrounded();
    }

    public override void CastSkill(float direction, GameObject player)
    {
        if (!CanCast(player)){ return; }
        player.GetComponent<PlayerMana>().Mana -= data.cost;
        var coroutine = WaitForSkillEnd(player);
        player.GetComponent<PlayerMovement>().StartCoroutine(coroutine); 
        
    }

   

    private IEnumerator WaitForSkillEnd(GameObject player)
    {
        player.GetComponent<Animator>().ResetTrigger("EndSkill");
        player.GetComponent<Animator>().SetTrigger("Parry");
        float time = 0;
        player.GetComponent<PlayerDeath>().ImmuneTo.Add(DamageType.Fire);
        while (time < _characteristics.parryDuration)
        {
            //parry projectiles
            yield return new WaitForFixedUpdate();
            time += Time.fixedDeltaTime;
        }
        player.GetComponent<PlayerDeath>().ImmuneTo.Remove(DamageType.Fire);
        player.GetComponent<Animator>().SetTrigger("EndSkill");
    }

}
