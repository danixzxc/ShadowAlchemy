using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallrunArea : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerWallrunSensor playerWalrunSensor = collider.GetComponent<PlayerWallrunSensor>();
        if (playerWalrunSensor != null)
        {
            playerWalrunSensor.SetWallrunAreaTrue();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        PlayerWallrunSensor playerWalrunSensor = collider.GetComponent<PlayerWallrunSensor>();
        if (playerWalrunSensor != null)
        {
            playerWalrunSensor.SetWallrunAreaFalse();
        }
    }

}
