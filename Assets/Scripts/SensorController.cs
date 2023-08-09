using UnityEngine;

public class SensorController : MonoBehaviour
{
    public Transform targetObjectTransform;
    private Rigidbody2D rb;

    private bool isHandled = false;
    private bool isThrowing = false;
    public float launchForce = 2f;

    Vector3 initialPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        getInitialPosition();
    }


   //If the sensors on the Player's body if block works; If the sensor is handled else block works.
    private void OnMouseDown()
    {
        if (isHandled == false) 
        {
            transformToHand();
            isHandled = true;
        }
        else
        {
            isThrowing = true;
        }
      
    }
 
    private void Update()
    {
        if (isHandled)
        {
            transformToHand();
        }
    }

    private void transformToHand()
    {
        transform.position = targetObjectTransform.position;
    }

    // When the sensor on the hand, this part works.
    private void OnMouseUp()
    {
        if (isThrowing == true)
        {
            isHandled = false;
            Throw();
            isThrowing = false;
        }

    }

    private void Throw()
    {
       
        rb.isKinematic = false;
        Vector3 dragVector = GetMouseWorldPosition() - transform.position;
        float angle = Mathf.Atan2(dragVector.y, dragVector.x);
        float magnitude = dragVector.magnitude;
        rb.AddForce(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * launchForce * magnitude, ForceMode2D.Impulse);
      
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    //Declaring of the sensors's initial position according to the Player
    private void getInitialPosition()
    {
        Vector3 playerPosition =  GameObject.Find("Player").transform.position;
        Vector3 sensorPosition = transform.position;
        initialPosition = sensorPosition - playerPosition;

    }

    //Returning the sensors to the inital position
    private void returnInitialPosition()
    {
        
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.rotation = 0;
        rb.transform.rotation = Quaternion.identity;

        rb.angularVelocity = 0f;
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        
        transform.position = playerPosition + initialPosition;


    }

    public void returnInitialPositionForInvoke(float sec)
    {
        Invoke("returnInitialPosition", sec);
    }
}




