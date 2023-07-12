using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity;

    float speedAmount = 10f;
    float jumpAmount = 15f;
    int maxJumpCount = 6; 
    int currentJumpCount = 0; 

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && currentJumpCount < maxJumpCount)
        {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
            currentJumpCount++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            currentJumpCount = 0;
        }
    }
}
