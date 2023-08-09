using UnityEngine;
using UnityEngine.VFX;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity;

    float speedAmount = 18f;
    float jumpAmount = 12f;
    int maxJumpCount = 6;
    int currentJumpCount = 0;

    /* Position limitation */
    public float maxXPosition = 80f;
    public GameObject[] sensorObjects;
    public GameObject[] sensorObjects2;
    public GameObject[] sensorObjects3;
    public GameObject[] sensorObjects4;

    public GameObject blockObjects;
    public GameObject blockObjects2;
    public GameObject blockObjects3;
    public GameObject blockObjects4;

    [SerializeField] private GameObject coupon1;
    [SerializeField] private GameObject coupon2;
    [SerializeField] private GameObject coupon3;
    [SerializeField] private GameObject coupon4;


    private bool isCouponActive = false;
    private float couponDuration = 7f;


    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;

        if (transform.position.x > maxXPosition)
        {
            transform.position = new Vector3(maxXPosition, transform.position.y, transform.position.z);
        }

        bool sensorsActive = false;
        for (int i = 0; i < sensorObjects.Length; i++)
        {
            if (sensorObjects[i] != null && sensorObjects[i].activeInHierarchy)
            {
                sensorsActive = true;
                break;
            }
        }

        if (!sensorsActive && maxXPosition == 100f)
        {
           blockObjects.SetActive(false);
            maxXPosition = 290f;
            sensorObjects = sensorObjects2; 

            StartCoroutine(ActivateCouponForDuration(coupon1, couponDuration));
        }

        sensorsActive = false;
        for (int i = 0; i < sensorObjects2.Length; i++)
        {
            if (sensorObjects2[i] != null && sensorObjects2[i].activeInHierarchy)
            {
                sensorsActive = true;
                break;
            }
        }

        if (!sensorsActive && maxXPosition == 290f)
        {
            blockObjects2.SetActive(false);
            maxXPosition = 585f;
            sensorObjects = sensorObjects3; 

            StartCoroutine(ActivateCouponForDuration(coupon2, couponDuration));
        }

        sensorsActive = false;
        for (int i = 0; i < sensorObjects3.Length; i++)
        {
            if (sensorObjects3[i] != null && sensorObjects3[i].activeInHierarchy)
            {
                sensorsActive = true;
                break;
            }
        }

        if (!sensorsActive && maxXPosition == 585f)
        {
            blockObjects3.SetActive(false);
            maxXPosition = 1060f;

            StartCoroutine(ActivateCouponForDuration(coupon3, couponDuration));
        }

        if (Input.GetButtonDown("Jump") && currentJumpCount < maxJumpCount)
        {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
            currentJumpCount++;
        }

        
        sensorsActive = false;
        for (int i = 0; i < sensorObjects4.Length; i++)
        {
            if (sensorObjects4[i] != null && sensorObjects4[i].activeInHierarchy)
            {
                sensorsActive = true;
                break;
            }
        }

        if (!sensorsActive && maxXPosition == 1060f)
        {
            blockObjects4.SetActive(false);
            maxXPosition = 1300f;
            sensorObjects = sensorObjects4; 

            StartCoroutine(ActivateCouponForDuration(coupon4, couponDuration));
        }

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
  
    private System.Collections.IEnumerator ActivateCouponForDuration(GameObject coupon, float duration)
    {
        isCouponActive = true;
        coupon.SetActive(true);

        yield return new WaitForSeconds(duration);

        coupon.SetActive(false);
        isCouponActive = false;
    }
}
