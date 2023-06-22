using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorControl : MonoBehaviour
{
    //Adding tags that they are not the project of Sensor1
    public string[] Tags = { "Sensor2"};
    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (string tag in Tags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                HealthManager.health--;
                break;
            }
        }
    }

}
