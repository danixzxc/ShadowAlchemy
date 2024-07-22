using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector3.right * 3* Time.deltaTime);
    }
}
