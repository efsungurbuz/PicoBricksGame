using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health = 15;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject restartButton;
    public LifeResetter liferesetter; 

    [SerializeField]
    public GameObject Player;

    private int initialHealth; // Store the initial health value

    private void Start()
    {
        restartButton.SetActive(false);
        initialHealth = health; // Store the initial health value at the start
    }

    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }

        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }

        if (health == 0)
        {
            Destroy(Player, 1f);
            restartButton.SetActive(true);
            if (liferesetter != null)
            {
                liferesetter.RestartGame(); // Restart the game using LifeResetter
            }
        }
    }

    public void ResetHealth()
    {
        health = initialHealth; // Reset health to its initial value
    }
}
