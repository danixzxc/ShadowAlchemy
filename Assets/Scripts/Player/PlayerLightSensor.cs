using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightSensor : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacteristics _playerCharacteristics;
    private float gainPerSecond;
    private float losePerSecond;

    private PlayerMana _playerMana;

    private int lightsCounter;

    void Start()
    {
        gainPerSecond = _playerCharacteristics.gainPerSecond;
        losePerSecond = _playerCharacteristics.losePerSecond;
        _playerMana = GetComponent<PlayerMana>();
        lightsCounter = 0;
    }

    void Update()
    {
        if (lightsCounter == 0){
            _playerMana.Mana += Time.deltaTime * gainPerSecond;
        }
        else {
            _playerMana.Mana -= Time.deltaTime * losePerSecond;
        }
    }

    public void AddLight(){
        lightsCounter++;
    }

    public void RemoveLight(){
        lightsCounter--;
    }
}
