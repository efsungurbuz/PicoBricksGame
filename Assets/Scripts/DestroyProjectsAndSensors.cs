using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectsAndSensors : MonoBehaviour
{
    public GameObject destroyEffect;  // Partikül efektini referans almak için bir değişken
    public string sensorTag;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(sensorTag))
         
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
