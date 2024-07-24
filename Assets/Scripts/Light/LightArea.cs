using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        PlayerLightSensor playerLightSensor = collider.GetComponent<PlayerLightSensor>();
        if(playerLightSensor != null){
            playerLightSensor.AddLight();
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        PlayerLightSensor playerLightSensor = collider.GetComponent<PlayerLightSensor>();
        if(playerLightSensor != null){
            playerLightSensor.RemoveLight();
        }
    }
}
