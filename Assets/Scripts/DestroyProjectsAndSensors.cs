using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectsAndSensors : MonoBehaviour
{
    public GameObject destroyEffect;  // Partikül efektini referans almak için bir değişken

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sensor1") ||
         collision.gameObject.CompareTag("Sensor2") ||
         collision.gameObject.CompareTag("Sensor3") ||
         collision.gameObject.CompareTag("Sensor4") ||
         collision.gameObject.CompareTag("Sensor5") ||
         collision.gameObject.CompareTag("Sensor6") ||
         collision.gameObject.CompareTag("Sensor7") ||
         collision.gameObject.CompareTag("Sensor8") ||
         collision.gameObject.CompareTag("Sensor9") ||
         collision.gameObject.CompareTag("Sensor10") ||
         collision.gameObject.CompareTag("Sensor11") ||
         collision.gameObject.CompareTag("Sensor12"))
        {
            // Efektli yok olma işlemi
            GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
            ParticleSystem particleSystem = effect.GetComponent<ParticleSystem>();
            particleSystem.Play();  // Particle System'ı etkinleştir

            Destroy(effect, particleSystem.main.duration);  // Efekti yok et
            Destroy(gameObject);  // İlk objeyi yok et
            Destroy(collision.gameObject);  // İkinci objeyi yok et
        }
    }
}
