using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DisableChildMovement : MonoBehaviour
{
    
        private Vector3 initialPosition;
        private bool isMoving = true;

        private void Start()
        {
            // �lk pozisyonu kaydet
            initialPosition = transform.position;
        }

        private void Update()
        {
            if (isMoving)
            {
                // Grubun pozisyonunu g�ncelle
                transform.position = initialPosition;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Ba�ka bir objeye �arpt���nda hareketi durdur
            isMoving = false;
        }
    }



