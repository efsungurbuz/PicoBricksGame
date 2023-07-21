using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreasingHealth : MonoBehaviour
{
    public GameObject skullObject;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthManager.health--;
            Destroy(skullObject);
        }

        
    }
}
