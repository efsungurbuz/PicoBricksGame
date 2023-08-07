using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CountdownTimerandDestroyer : MonoBehaviour
{
    public GameObject targetObject;
    [SerializeField] private Image uiFill;
    [SerializeField] private Text uiText;
    [SerializeField] private Image secondImage;

    private int Duration = 60;
    private int remainingDuration;
    private bool isCountdownStarted = false;
    private bool isPaused = false;

    private void Start()
    {
        // Initialize UI elements
        uiText.text = "00 : 00";
        uiFill.fillAmount = 0;

        // Set UI elements as initially invisible
        uiFill.enabled = false;
        uiText.enabled = false;

        // Hide the secondImage initially
        secondImage.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCountdownStarted)
        {
            // Make UI elements visible when triggered
            uiFill.enabled = true;
            uiText.enabled = true;

            // Show the secondImage for 5 seconds
            StartCoroutine(ShowSecondImageFor5Seconds());

            StartCountdown();
            isCountdownStarted = true;
        }
    }

    private void StartCountdown()
    {
        remainingDuration = Duration;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            if (!isPaused)
            {
                uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
        OnEnd();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
    }

    private void OnEnd()
    {
        Destroy(targetObject); // Hedef objeyi yok et
    }

    private IEnumerator ShowSecondImageFor5Seconds()
    {
        secondImage.enabled = true;
        yield return new WaitForSeconds(5f);
        secondImage.enabled = false;
    }
}
