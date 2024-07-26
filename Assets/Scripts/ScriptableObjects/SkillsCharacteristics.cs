
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SkillsCharacteristics", order = 5)]

public class SkillsCharacteristics : ScriptableObject

{
    [Header("Dash")]
    public float dashVelocity;
    public float dashDistance;
    public float dashFinalVelocityPercent;

    [Space(10), Header("Backstep")]
    public float backstepVelocity;
    public float backstepDistance;
    public float backstepFinalVelocityPercent;

}