
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SkillsCharacteristics", order = 5)]

public class SkillsCharacteristics : ScriptableObject

{
    public float dashVelocity;
    public float dashDistance;
    public float finalVelocityPercent;
}