using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerCharacteristics", order = 3)]
public class PlayerCharacteristics : ScriptableObject
{
    [Header("Movement")]
    public float startHorizontalVelocity;
    public float maxHorizontalVelocity;
    public float runningAcceleration;
    public float jumpVelocity;
    [Header("Mana")]
    [Tooltip("Amount of mana player with start with. Is measured in segments, so its an integer.")]
    public int startingManaSegments;
    [Header("In Shadow")]
    [SerializeField]
    public float gainPerSecond;
    [Header("In Light")]
    [SerializeField]
    public float losePerSecondPerLight; 

}
