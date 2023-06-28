using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health = 15;
    public Image[] hearths;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        foreach (Image img in hearths)
        {
            img.sprite = emptyHeart;
        }

        for (int i = 0; i < health; i++)
        {
            hearths[i].sprite = fullHeart;
        }
    }
}
