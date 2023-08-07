using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 cameraOffset;
    public Vector3 targetedPosition;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.2F;

    [SerializeField]
    private Camera cam;
    private Vector3 dragOrigin;

    [SerializeField]
    private float zoomStep, minCamSize, maxCamSize;

    private bool spacePressed = false;

    /* Camera follow settings */
    void LateUpdate()
    {
        if (!spacePressed) // Sadece space basýlmadýðýnda kamera takibi ve yakýnlaþtýrma iþlemleri yap
        {
            targetedPosition = targetObject.transform.position + cameraOffset;
            targetedPosition.y += 5;
            // Smoothing Camera
            transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref velocity, smoothTime);
            PanCamera();
            HandleZoom();
        }
    }
    /* Zoom in and out settings */
    private void Update()
    {
        // Space tuþunun durumunu kontrol eder ve ona göre iþlem yapar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            spacePressed = false;
        }
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(2))
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(2))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += difference;
        }
    }

    private void HandleZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            ZoomIn();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            ZoomOut();
        }
    }

    public void ZoomIn()
    {
        float newSize = cam.orthographicSize - zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }

    public void ZoomOut()
    {
        float newSize = cam.orthographicSize + zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }
}
