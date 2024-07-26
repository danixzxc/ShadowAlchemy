using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopRotator : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacteristics _playerCharacteristics;
    public void UpdateRotation(Vector2 pos){
        
        transform.eulerAngles = new Vector3(0.0f, 0.0f, ClampAngle(Mathf.Atan2(pos.y, pos.x)*Mathf.Rad2Deg) * _playerCharacteristics.upperBodyHalfSensitivity);
    }

    private float ClampAngle(float angle){
        if(angle > 0.0f){
            return Mathf.Min(_playerCharacteristics.maxUpperAngle, angle);
        }
        else{
            return Mathf.Max(-_playerCharacteristics.maxLowerAngle, angle);
        }
    }
}
