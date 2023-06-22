using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject hand; // Hand objesini referans almak i�in bir de�i�ken

    private void OnMouseDown()
    {
        Vector3 handPosition = hand.transform.position; // Hand objesinin konumunu al
        transform.position = new Vector3(handPosition.x, handPosition.y, transform.position.z); // Sens�r objesinin X, Y ve Z konumunu g�ncelle

    }
}




