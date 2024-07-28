using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineObjectFollower : MonoBehaviour
{
    public Transform obj;
    private LineRenderer line;
    void Start(){
        line = GetComponent<LineRenderer>();
    }
    void Update(){
        Vector3[] points = {transform.position, obj.position};
        line.SetPositions(points);
    }
}
