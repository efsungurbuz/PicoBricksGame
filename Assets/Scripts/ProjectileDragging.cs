using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDragging : MonoBehaviour
{
    private bool clickedOn;
    private Vector3 dragOffset;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseUp()
    {
        clickedOn = false;
        rb.isKinematic = false;
        Vector3 dragVector = GetMouseWorldPosition() - transform.position;
        float angle = Mathf.Atan2(dragVector.y, dragVector.x);
        float magnitude = dragVector.magnitude;
        float launchForce = 5f; // F?rlatma kuvveti (istedi?iniz de?eri ayarlayabilirsiniz)
        rb.AddForce(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * launchForce * magnitude, ForceMode2D.Impulse);
    }


    private void Update()
    {
        if (clickedOn)
        {
            Dragging();
        }
    }

    private void Dragging()
    {
        Vector3 mouseWorldPoint = GetMouseWorldPosition() + dragOffset;
        mouseWorldPoint.z = 0f;
        transform.position = mouseWorldPoint;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
