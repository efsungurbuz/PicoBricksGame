using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimerandDestroyer : MonoBehaviour
{
    public GameObject targetObject; // Throwing area object
    public float countdownDuration = 60f; // Geri sayým süresi (2 dakika)

    private bool playerTouched = false;
    private float currentTime = 0f;

    void Update()
    {
        if (playerTouched)
        {
            // Oyuncu temas ettiðinde geri sayým baþlar
            currentTime += Time.deltaTime;

            if (currentTime >= countdownDuration)
            {
                // Geri sayým tamamlandý, "y" objesini yok et
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
