using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDecreaser : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBody"))
        {
            HealthManager.health--;
        }
    }
}
