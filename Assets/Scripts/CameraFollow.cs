using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 cameraOffset;
    public Vector3 targetedPosition;
    private Vector3 velocity = Vector3.zero; // It is a non-important reference for 
    
    public float smoothTime = 0.2F;
 void LateUpdate()
    {
        targetedPosition = targetObject.transform.position + cameraOffset;
        targetedPosition.y += 5;
        //Smoothing Camera
        transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref velocity, smoothTime);
    }
}
