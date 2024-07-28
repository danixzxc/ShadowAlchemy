
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
    
    [Space(10), Header("Jump")]
    [Range(0.0f, 10.0f)]
    public float jumpMultiplier = 1.0f;
    [Range(0.0f, 1.0f)]
    public float landingMultiplier = 1.0f;

    [Space(10), Header("Wallrun")]
    public float wallrunDistance;
    public float wallrunAngle;
    public float wallrunFinalVelocityPercent;

    [Space(10), Header("Shuriken")]
    public GameObject shurikenPrefab;
    public float shurikenSpeed;
    public float shurikenDamage;

    [Space(10), Header("Weight")]
    public GameObject weightPrefab;
    public float weightGravityMultiplier;
    public float weightMinimalVelocity;
    public float weightDamage;

    [Space(10), Header("SmokeBomb")]
    public GameObject smokeBombPrefab;
    public float smokeInvisTime;

    [Space(10), Header("Grappling Hook")]
    public GameObject hookPrefab;
    public float hookTimeLimit;
    public float hookSpeed;
    public float hookEnemyPullSpeed;
    public float hookDamage;
    public float hookPlayerTravelSpeed;

    [Space(10), Header("Sword")]
    public GameObject swordPrefab;
    public float swordSpeed;
    public float swordDamage;
    public float swordBounceSpeed;
    public float swordBounceDelay;
    public float swordBounceSlowdown;

    [Space(10), Header("Concentration")]
    public float concentrationDuration;
    public float concentrationTimeSpeedPercent;
    [Range(0.0f, 0.2f)]
    public float concentrationDesaturationPercent = 0.1f;

    [Space(10), Header("Spinning Attack")]
    public GameObject spinningAttackHitbox;
    public float spinningAttackVelocity;
    public float spinningAttackDistance;
    public float spinningAttackDamage; 
    public float spinningAttackFinalVelocityPercent;

}