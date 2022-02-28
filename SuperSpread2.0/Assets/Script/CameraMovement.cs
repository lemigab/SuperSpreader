using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    //public float smooth_speed = 0.125f;
    public Vector3 offset;
    [Range(1,10)]
    public float smooth_factor;

    // LateUpdate is called once per frame after Update
    void LateUpdate()
    {
        Follow();
        
    }

    // Makes the camera follow a target sprite (Player sprite)
    void Follow()
    {
        Vector3 target_position = target.position + offset;
        Vector3 smooth_postion = Vector3.Lerp(transform.position, target_position, smooth_factor * Time.deltaTime);
        transform.position = smooth_postion;
    }
}
