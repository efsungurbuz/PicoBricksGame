using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        Vector3 dragVector = GetMouseWorldPosition() - transform.position;
        float angle = Mathf.Atan2(dragVector.y, dragVector.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = newRotation;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

}
