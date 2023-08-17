using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeResetter : MonoBehaviour
{
    public int decreaseAmount = 1;
    public GameObject restartButton; 

    HealthManager healthManager;
    [SerializeField]
    public GameObject Player;
    bool isPlayerDead = false;

    void Start()
    {
        // Başlangıçta butonu etkisiz hale getirin (gizleyin)
        restartButton.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isPlayerDead)
        {
            StartCoroutine(DecreaseHealthOverTime(HealthManager.health));
        }
    }

    IEnumerator DecreaseHealthOverTime(int startingHealth)
    {
        isPlayerDead = true;

        for (int i = startingHealth; i > 0; i--)
        {
            yield return new WaitForSeconds(0.6f); // Her adımda bekleme süresi
            HealthManager.health -= decreaseAmount;
        }

        Destroy(Player, 1f);
        restartButton.SetActive(true);
        // Restarting the game should happen only when the restart button is pressed, so we remove it from here
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        HealthManager.health = 15;
    }
}
