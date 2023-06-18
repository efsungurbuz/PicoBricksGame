using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialText : MonoBehaviour
{
    public GameObject imageObject;
    public float displayDuration = 5f;

    private void Start()
    {
        imageObject.SetActive(true); // Resmi baþlangýçta etkinleþtirin
        Invoke("HideImage", displayDuration);
    }

    private void HideImage()
    {
        imageObject.SetActive(false); // Resmi gizleyin
    }
}

