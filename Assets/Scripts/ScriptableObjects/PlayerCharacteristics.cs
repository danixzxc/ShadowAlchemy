using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerCharacteristics", order = 3)]
public class PlayerCharacteristics : ScriptableObject
{
    public float startHorizontalVelocity;
    public float maxHorizontalVelocity;
    public float runningAcceleration;
    public float jumpVelocity;
}
