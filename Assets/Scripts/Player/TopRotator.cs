using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopRotator : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacteristics _playerCharacteristics;
    public void UpdateAngle(float angle){
        if(!enabled){return;}
        transform.eulerAngles = new Vector3(0.0f, 0.0f, angle * _playerCharacteristics.upperBodyHalfSensitivity);
    }
    void OnDisable()
    {
        transform.eulerAngles = Vector3.zero;
    }
}
