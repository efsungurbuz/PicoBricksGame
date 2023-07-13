using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeResetter : MonoBehaviour
{
    public int decreaseAmount = 1; // Her temas ettiğinde düşecek can miktarı

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DecreaseHealthOverTime(HealthManager.health));
        }
    }

    IEnumerator DecreaseHealthOverTime(int startingHealth)
    {
        for (int i = startingHealth; i > 0; i--)
        {
            yield return new WaitForSeconds(0.6f); // Her adımda bekleme süresi
            HealthManager.health -= decreaseAmount;
        }

        RestartGame();
    }

    void RestartGame()
    {
      
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        HealthManager.health = 15;
    }
}
