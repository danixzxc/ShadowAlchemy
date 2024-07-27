using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiParentRotator : MonoBehaviour
{
    void Update()
    {
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, -transform.parent.eulerAngles.z);
    }
}
