using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class ConcentrationSkill :  Skill
{
    private SkillsCharacteristics _characteristics;

    private Image _desaturationImage;
    public ConcentrationSkill()
    {
        data = CombinationManager.Instance.GetSkillData("concentration");
        _characteristics = CombinationManager.Instance.GetSkillsCharacteristics();
    }

    public override bool CanCast(GameObject player) {
        return player.GetComponent<PlayerMana>().Mana > data.cost;
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
        _desaturationImage = GameObject.Find("/Canvas/DesaturationImage").GetComponent<Image>();
        var image = _desaturationImage;
        var color = image.color;
       // image.color = Color.Lerp(color, new Color(color.r, color.g, color.b, .25f), 1);
        image.color = new Color(color.r, color.g, color.b, _characteristics.concentrationDesaturationPercent);
        float time = 0;
        float realtime = _characteristics.concentrationDuration / 100 * _characteristics.concentrationTimeSpeedPercent;
        Time.timeScale = _characteristics.concentrationTimeSpeedPercent / 100;
        while (time < realtime)
        {
            yield return new WaitForFixedUpdate();
            time += Time.fixedDeltaTime;
        }
        Time.timeScale = 1f;
        image.color = new Color(color.r, color.g, color.b, 0);
        //image.color = Color.Lerp(color, new Color(color.r, color.g, color.b, 0), 1);
    }

}
