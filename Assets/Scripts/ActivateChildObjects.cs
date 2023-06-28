using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateChildObjects : MonoBehaviour
{
    public GameObject object3; // Reference to the 3rd object in the scene
    public GameObject object5; // Reference to the 5th object in the scene

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            object3.SetActive(true); // Activate the 3rd object
            object5.SetActive(true); // Activate the 5th object
        }
        else
        {
            object3.SetActive(false);

        }
    }
}
