using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePop : MonoBehaviour
{
    public GameObject Message;
    public GameObject SecondText;
    public GameObject ThirdText;
    public GameObject FourthText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Message.SetActive(true);
        }
    }
  
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Message.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(BoxCollider2D other)
    {
        if (other.CompareTag("Track2"))
        {
            SecondText.SetActive(true);
        }
        else if (other.CompareTag("Track3"))
        {
            ThirdText.SetActive(true);
        }
        else if (other.CompareTag("Track4"))
        {
            FourthText.SetActive(true);
        }
    }

}
