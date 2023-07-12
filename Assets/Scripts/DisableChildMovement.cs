using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DisableChildMovement : MonoBehaviour
{
    
        private Vector3 initialPosition;
        private bool isMoving = true;

        private void Start()
        {
            
            initialPosition = transform.position;
        }

        private void Update()
        {
            if (isMoving)
            {
             
                transform.position = initialPosition;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            
            isMoving = false;
        }
    }



