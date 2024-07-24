using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightSensor : MonoBehaviour
{
    [Header("In Shadow")]
    [SerializeField]
    private float gainPerSecond;
    [Header("In Light")]
    [SerializeField]
    private float losePerSecondPerLight;

    private PlayerMana _playerMana;

    private int lightsCounter;

    void Start()
    {
        _playerMana = GetComponent<PlayerMana>();
        lightsCounter = 0;
    }

    void Update()
    {
        if (lightsCounter == 0){
            _playerMana.Mana += Time.deltaTime * gainPerSecond;
        }
        else {
            _playerMana.Mana -= Time.deltaTime * losePerSecondPerLight * lightsCounter;
        }
    }

    public void AddLight(){
        lightsCounter++;
    }

    public void RemoveLight(){
        lightsCounter--;
    }
}
