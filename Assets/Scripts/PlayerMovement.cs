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
    public GameObject[] birdObjects;
    public GameObject[] birdObjects2;
    public GameObject[] birdObjects3;
    public GameObject[] birdObjects4;

    [SerializeField]
    private GameObject coupon1;
    [SerializeField]
    private GameObject coupon2;
    [SerializeField]
    private GameObject coupon3;
    [SerializeField]
    private GameObject coupon4;

    private bool isCouponActive = false;
    private float couponDuration = 3f;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;

        // Player'ýn X pozisyonunu sýnýrlama
        if (transform.position.x > maxXPosition)
        {
            transform.position = new Vector3(maxXPosition, transform.position.y, transform.position.z);
        }

        // Kuþ objeleri kontrolü
        bool birdsActive = false;
        for (int i = 0; i < birdObjects.Length; i++)
        {
            if (birdObjects[i] != null && birdObjects[i].activeInHierarchy)
            {
                birdsActive = true;
                break;
            }
        }

        // Ýlk grup kuþ objeleri yok olduðunda maxXPosition deðerini güncelle
        if (!birdsActive && maxXPosition == 80f)
        {
            maxXPosition = 290f;
            birdObjects = birdObjects2; // Ýkinci grup kuþ objelerini aktif hale getir

            StartCoroutine(ActivateCouponForDuration(coupon1, couponDuration));
        }

        // Ýkinci grup kuþ objeleri kontrolü
        birdsActive = false;
        for (int i = 0; i < birdObjects2.Length; i++)
        {
            if (birdObjects2[i] != null && birdObjects2[i].activeInHierarchy)
            {
                birdsActive = true;
                break;
            }
        }

        // Ýkinci grup kuþ objeleri yok olduðunda maxXPosition deðerini güncelle
        if (!birdsActive && maxXPosition == 290f)
        {
            maxXPosition = 547.3f;
            birdObjects = birdObjects3; // Üçüncü grup kuþ objelerini aktif hale getir

            StartCoroutine(ActivateCouponForDuration(coupon2, couponDuration));
        }

        // Üçüncü grup kuþ objeleri kontrolü
        birdsActive = false;
        for (int i = 0; i < birdObjects3.Length; i++)
        {
            if (birdObjects3[i] != null && birdObjects3[i].activeInHierarchy)
            {
                birdsActive = true;
                break;
            }
        }

        // Üçüncü grup kuþ objeleri yok olduðunda maxXPosition deðerini güncelle
        if (!birdsActive && maxXPosition == 547.3f)
        {
            maxXPosition = 1060f;

            StartCoroutine(ActivateCouponForDuration(coupon3, couponDuration));
        }

        if (Input.GetButtonDown("Jump") && currentJumpCount < maxJumpCount)
        {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
            currentJumpCount++;
        }

        /*dört deneme */

        // Üçüncü grup kuþ objeleri yok olduðunda maxXPosition deðerini güncelle
        if (!birdsActive && maxXPosition == 1060f)
        {
            maxXPosition = 1200f;
            birdObjects = birdObjects4; // Üçüncü grup kuþ objelerini aktif hale getir

            StartCoroutine(ActivateCouponForDuration(coupon2, couponDuration));
        }
        // Dördüncü grup kuþ objeleri kontrolü
        birdsActive = false;
        for (int i = 0; i < birdObjects4.Length; i++)
        {
            if (birdObjects4[i] != null && birdObjects4[i].activeInHierarchy)
            {
                birdsActive = true;
                break;
            }
        }

        // Üçüncü grup kuþ objeleri yok olduðunda maxXPosition deðerini güncelle
        if (!birdsActive && maxXPosition == 1060f)
        {
            maxXPosition = 1200f;

            StartCoroutine(ActivateCouponForDuration(coupon3, couponDuration));
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
