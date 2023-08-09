using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectsAndSensors : MonoBehaviour
{
    public GameObject destroyEffect;  
    public string sensorTag;

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(sensorTag))
         
        {
           
            GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
            ParticleSystem particleSystem = effect.GetComponent<ParticleSystem>();
            particleSystem.Play();  

            Destroy(effect, particleSystem.main.duration);  
            Destroy(gameObject);  
            Destroy(collision.gameObject); 
        }
    }
}
