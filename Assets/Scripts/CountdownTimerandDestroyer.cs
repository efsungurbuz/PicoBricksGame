using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimerandDestroyer : MonoBehaviour
{
    public GameObject targetObject; // Throwing area object
    public float countdownDuration = 60f; // Geri say�m s�resi (2 dakika)

    private bool playerTouched = false;
    private float currentTime = 0f;

    void Update()
    {
        if (playerTouched)
        {
            // Oyuncu temas etti�inde geri say�m ba�lar
            currentTime += Time.deltaTime;

            if (currentTime >= countdownDuration)
            {
                // Geri say�m tamamland�, "y" objesini yok et
                Destroy(targetObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerTouched = true;
        }
    }
}
