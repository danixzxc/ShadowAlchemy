using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightSensor : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacteristics _playerCharacteristics;
    private float gainPerSecond;
    private float losePerSecondPerLight;

    private PlayerMana _playerMana;

    private int lightsCounter;

    void Start()
    {
        gainPerSecond = _playerCharacteristics.gainPerSecond;
        losePerSecondPerLight = _playerCharacteristics.losePerSecondPerLight;
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
