using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightArea : MonoBehaviour
{
    private bool _prevEnabled;
    private bool _enabledChanged;
    public new bool enabled;

    void OnTriggerEnter2D(Collider2D collider){
        if (!enabled) { return; }
        PlayerLightSensor playerLightSensor = collider.GetComponent<PlayerLightSensor>();
        if(playerLightSensor != null){
            playerLightSensor.AddLight();
        }
    }

    void OnTriggerStay2D(Collider2D collider){
        if (!_enabledChanged) { return; }
        PlayerLightSensor playerLightSensor = collider.GetComponent<PlayerLightSensor>();
        if(playerLightSensor != null){
            if (enabled){
                playerLightSensor.AddLight();
            }
            else{
                playerLightSensor.RemoveLight();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if (!enabled) { return; }
        PlayerLightSensor playerLightSensor = collider.GetComponent<PlayerLightSensor>();
        if(playerLightSensor != null){
            playerLightSensor.RemoveLight();
        }
    }

    void FixedUpdate(){
        _enabledChanged = false;
        if(enabled != _prevEnabled){
            _enabledChanged = true;
        }
        _prevEnabled = enabled;
    }
}
