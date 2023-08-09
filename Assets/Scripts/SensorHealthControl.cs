using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorHealthControl : MonoBehaviour
{
    SensorController sensorController;

    //Adding tags that they are not the project of sensors.
    public string[] Tags = { "Sensor2", "Project3"};


    void Start()
    {
        sensorController = GetComponent<SensorController>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!string.IsNullOrEmpty(collision.gameObject.tag))
        {
            foreach (string tag in Tags)
            {
                if (collision.gameObject.CompareTag(tag))
                {
                    HealthManager.health--;
                    sensorController.returnInitialPositionForInvoke(1);
                    break;
                }
                
            }
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            sensorController.returnInitialPositionForInvoke(1);

        }
    }

    
}
