using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMover : MonoBehaviour
{
    public void UpdatePosition(Vector2 pos){
        transform.localPosition = new Vector3(pos.x, pos.y, 0.0f);
    }
}
