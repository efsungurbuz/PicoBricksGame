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

        // Player'�n X pozisyonunu s�n�rlama
        if (transform.position.x > maxXPosition)
        {
            transform.position = new Vector3(maxXPosition, transform.position.y, transform.position.z);
        }

        // sensor objeleri kontrol�
        bool sensorsActive = false;
        for (int i = 0; i < birdObjects.Length; i++)
        {
            if (birdObjects[i] != null && birdObjects[i].activeInHierarchy)
            {
                sensorsActive = true;
                break;
            }
        }

        // �lk grup sensor objeleri yok oldu�unda maxXPosition de�erini g�ncelle
        if (!sensorsActive && maxXPosition == 100f)
        {
           blockObjects.SetActive(false);
            maxXPosition = 290f;
            birdObjects = birdObjects2; // �kinci grup sensor objelerini aktif hale getir

            StartCoroutine(ActivateCouponForDuration(coupon1, couponDuration));
        }

        // �kinci grup sensor objeleri kontrol�
        sensorsActive = false;
        for (int i = 0; i < birdObjects2.Length; i++)
        {
            if (birdObjects2[i] != null && birdObjects2[i].activeInHierarchy)
            {
                sensorsActive = true;
                break;
            }
        }

        // �kinci grup sensor objeleri yok oldu�unda maxXPosition de�erini g�ncelle
        if (!sensorsActive && maxXPosition == 290f)
        {
            blockObjects2.SetActive(false);
            maxXPosition = 585f;
            birdObjects = birdObjects3; // ���nc� grup sensor objelerini aktif hale getir

            StartCoroutine(ActivateCouponForDuration(coupon2, couponDuration));
        }

        // ���nc� grup sensor objeleri kontrol�
        sensorsActive = false;
        for (int i = 0; i < birdObjects3.Length; i++)
        {
            if (birdObjects3[i] != null && birdObjects3[i].activeInHierarchy)
            {
                sensorsActive = true;
                break;
            }
        }

        // ���nc� grup sensor objeleri yok oldu�unda maxXPosition de�erini g�ncelle
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

        
        // D�rd�nc� grup sensor objeleri kontrol�
        sensorsActive = false;
        for (int i = 0; i < birdObjects4.Length; i++)
        {
            if (birdObjects4[i] != null && birdObjects4[i].activeInHierarchy)
            {
                sensorsActive = true;
                break;
            }
        }

        // D�rd�nc� grup sensor objeleri yok oldu�unda maxXPosition de�erini g�ncelle
        if (!sensorsActive && maxXPosition == 1060f)
        {
            blockObjects4.SetActive(false);
            maxXPosition = 1300f;
            birdObjects = birdObjects4; // D�rd�nc� grup sensor objelerini aktif hale getir

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
