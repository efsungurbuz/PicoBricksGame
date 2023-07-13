using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorControl : MonoBehaviour
{
    //Adding tags that they are not the project of Sensor1
    public string[] Tags = { "Sensor2", "Project3"};
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!string.IsNullOrEmpty(collision.gameObject.tag))
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


}
