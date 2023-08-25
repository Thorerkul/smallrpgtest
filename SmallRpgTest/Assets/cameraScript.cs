using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Transform target;
    [Range(0.0001f, 1f)]
    public float division;

    void FixedUpdate()
    {
        Vector3 newPos = (transform.position - target.position) * division;
        transform.position -= new Vector3(newPos.x, newPos.y, 0);
    }
}
