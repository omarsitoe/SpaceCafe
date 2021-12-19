using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3F;

    Vector3 offset;
    Vector3 vel = Vector3.zero;
    
    
    void Start()
    {
        //initialize position variables
        target = transform.parent;
        transform.parent = null;
        transform.position = target.position;

        offset = new Vector3(0, 0, -30);
    }

    void LateUpdate()
    {
        //find target position
        offset = new Vector3(target.position.x, target.position.y, -30);

        //smoothly move the camera towards player
        transform.position = Vector3.SmoothDamp(transform.position, offset, ref vel, smoothTime);
    }
}
