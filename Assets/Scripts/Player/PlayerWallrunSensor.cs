using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallrunSensor : MonoBehaviour
{
    private bool _inWallrunArea;

    public void SetWallrunAreaTrue()
    {
        _inWallrunArea = true;
    }

    public void SetWallrunAreaFalse()
    {
        _inWallrunArea = false;
    }

    public bool GetWallrunAreaIntersection()
    {
        return _inWallrunArea;
    }
}
