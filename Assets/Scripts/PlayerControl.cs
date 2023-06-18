using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject hand; // Hand objesini referans almak i�in bir de�i�ken

    private bool hasRigidbody = false; // RigidBody bile�eninin mevcut olup olmad���n� izlemek i�in bir de�i�ken

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !hasRigidbody)
        {
            AddRigidbody();
        }
    }

    private void AddRigidbody()
    {
        Rigidbody2D rigidbodyComponent = gameObject.AddComponent<Rigidbody2D>(); // RigidBody bile�enini ekle
        rigidbodyComponent.gravityScale = 0f; // Gravitasyonu kapatmak i�in

        hasRigidbody = true;
    }

    private void OnMouseDown()
    {
        Vector3 handPosition = hand.transform.position; // Hand objesinin konumunu al
        transform.position = new Vector3(handPosition.x, handPosition.y, transform.position.z); // Sens�r objesinin X, Y ve Z konumunu g�ncelle
    }
}




