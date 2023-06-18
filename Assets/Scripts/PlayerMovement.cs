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

        /* 16.06 */

        // do something with the item
        
    }





    //Destroy(gameObject.GetComponent<Rigidbody2D>());





    //const float movementPower = 10;


    //// Update is called once per frame
    //void Update()
    //{
    //    Vector3 position = transform.position; // Store the current position of Player.

    //    float horizontalInput = Input.GetAxis("Horizontal");
    //    float verticalInput = Input.GetAxis("Vertical");

    //    if (horizontalInput != 0)
    //    {
    //        position.x += horizontalInput * movementPower * Time.deltaTime;

    //    }
    //    if (verticalInput != 0)
    //    {
    //        position.y += verticalInput * movementPower * Time.deltaTime;
    //    }

    //    transform.position = new Vector3(position.x, position.y, 0); ;
    //    transform.rotation = Quaternion.Euler(0, 0, 0);

    //}
}

