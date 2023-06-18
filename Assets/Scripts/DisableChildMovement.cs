using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DisableChildMovement : MonoBehaviour
{
    
        private Vector3 initialPosition;
        private bool isMoving = true;

        private void Start()
        {
            // Ýlk pozisyonu kaydet
            initialPosition = transform.position;
        }

        private void Update()
        {
            if (isMoving)
            {
                // Grubun pozisyonunu güncelle
                transform.position = initialPosition;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Baþka bir objeye çarptýðýnda hareketi durdur
            isMoving = false;
        }
    }



