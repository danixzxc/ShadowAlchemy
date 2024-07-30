using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawningPoint;

    public float cooldown;

    public float angle = -180;

    private float time;

    void Update(){
        time += Time.deltaTime;
        if (time >= cooldown){
            time -= cooldown;
            GameObject fireball = Instantiate(prefab, spawningPoint);
            fireball.GetComponent<Fireball>().SetAngle(angle);
        }
    }
}
