using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructComponent : MonoBehaviour
{
    public void SelfDestruct(){
        Destroy(this.gameObject);
    }
}
