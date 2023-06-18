using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject hand; // Hand objesini referans almak için bir deðiþken

    private bool hasRigidbody = false; // RigidBody bileþeninin mevcut olup olmadýðýný izlemek için bir deðiþken

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !hasRigidbody)
        {
            AddRigidbody();
        }
    }

    private void AddRigidbody()
    {
        Rigidbody2D rigidbodyComponent = gameObject.AddComponent<Rigidbody2D>(); // RigidBody bileþenini ekle
        rigidbodyComponent.gravityScale = 0f; // Gravitasyonu kapatmak için

        hasRigidbody = true;
    }

    private void OnMouseDown()
    {
        Vector3 handPosition = hand.transform.position; // Hand objesinin konumunu al
        transform.position = new Vector3(handPosition.x, handPosition.y, transform.position.z); // Sensör objesinin X, Y ve Z konumunu güncelle
    }
}


    //private void Update()
    //{
    //    if (rigidbodyComponent.simulated && rigidbodyComponent.IsSleeping())
    //    {
    //        rigidbodyComponent.WakeUp(); // Rigidbody uyku durumundaysa uyanmasýný saðla
    //    }
    //}


