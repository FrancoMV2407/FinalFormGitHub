using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public Image[] hearts;

    public AudioSource audioSource;

    private int maxHP = 3;
    private int currentHP;

    public GameObject player;
    public GameObject deathScreen;

    public Transform cameraTransform; // Transform of main cam
    public float shakeDuration = 0.2f; // Duration of shake
    public float shakeMagnitude = 0.1f; // Intensity of shake

    private Vector3 initialCameraPosition; // OG cam position

    void Start()
    {
        deathScreen.SetActive(false);

        currentHP = maxHP;

        initialCameraPosition = cameraTransform.localPosition;
    }

    public void TakeDamage()
    {
        audioSource.Play();

        if (currentHP > 0)
        {
            currentHP--;
            UpdateHP();
            StartCoroutine(CameraShake());

            if (currentHP <= 0)
            {
                GameOver();
            }
        }
    }

    private void UpdateHP()
    {
        for (int i = 0;  i < hearts.Length; i++)
        {
            if (i < currentHP)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void GameOver()
    {
        Destroy(player);

        deathScreen.SetActive(true);
    }

    private System.Collections.IEnumerator CameraShake()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * shakeMagnitude;
            cameraTransform.localPosition = initialCameraPosition + randomOffset;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cameraTransform.localPosition = initialCameraPosition;
    }
}
