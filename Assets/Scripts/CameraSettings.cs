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

    [SerializeField]
    private Camera cam;
    private Vector3 dragOrigin;

    [SerializeField]
    private float zoomStep, minCamSize, maxCamSize;

    /* Camera follow settings */
    void LateUpdate()
    {
        targetedPosition = targetObject.transform.position + cameraOffset;
        targetedPosition.y += 5;
        //Smoothing Camera
        transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref velocity, smoothTime);
    }

    /* Zoom in and out settings  */
    private void Update()
    {
        PanCamera();
    }

    private void PanCamera()
    {
        // save position of mouse in world space when drag stars (first time clicked)

        if (Input.GetMouseButtonDown(2))
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        // calculate distance between drag origin and new position if it is still held down

        if (Input.GetMouseButton(2))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            print("origin" + dragOrigin + "newPosition" + cam.ScreenToWorldPoint(Input.mousePosition) + " =difference" + difference);

            //move the camera by that distance
            cam.transform.position += difference;
        }

    }

    public void ZoomIn()
    {
        float newSize = cam.orthographicSize - zoomStep; // Düzeltme: zoomStep deðeri eksi alýnmalý.

        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize); // Düzeltme: orthographicSize deðeri atamalý.
    }

    public void ZoomOut()
    {
        float newSize = cam.orthographicSize + zoomStep;

        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }

}
