using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMover : MonoBehaviour
{
    public float rotationOffset;
    public void UpdatePosition(Vector2 pos){
        transform.localPosition = new Vector3(pos.x, pos.y, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, 0.0f, Mathf.Atan2(pos.y, pos.x)*Mathf.Rad2Deg+rotationOffset);
    }
}
