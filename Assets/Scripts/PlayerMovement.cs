using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity;

    float SpeedAmount = 7f;
    float jumpAmount = 15f;
    private MonoBehaviour item;


    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * SpeedAmount * Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
        }

     
        
    }


}

