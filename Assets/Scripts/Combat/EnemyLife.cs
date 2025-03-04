using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{
    public EnemyStats enemyStats;

    private float currentLife;

    public PlayerDamage playerDamage;

    public Transform bossBar;
    public Image fillBar;
    public GameObject damagedBar;

    public float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.1f;

    private Vector3 initialBossBarPosition;

    public GameObject enemy;
    public GameObject winScreen;

    private Color hurtColor;

    void Start()
    {
        currentLife = enemyStats.maxLife;

        damagedBar.SetActive(false);

        fillBar.color = Color.white;
        hurtColor = new Color(1, 0.3f, 0.3f);
    }

    public void TakeDamage()
    {
        if(currentLife > 0)
        {
            currentLife -= playerDamage.playerDmg * enemyStats.df;
            UpdateHealth();
            StartCoroutine(DamagedBarEffect());

            if (currentLife <= 0)
            {
                WinScene();
                Destroy(enemy);
            }
        }
    }

    public void WinScene()
    {
        winScreen.SetActive(true);
    }

    public void UpdateHealth()
    {
        float normalizedHP = currentLife / enemyStats.maxLife;

        fillBar.fillAmount = normalizedHP;
    }

    private System.Collections.IEnumerator DamagedBarEffect()
    {
        damagedBar.SetActive(true);

        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * shakeMagnitude;
            bossBar.localPosition = initialBossBarPosition + randomOffset;
            fillBar.color = hurtColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fillBar.color = Color.white;

        bossBar.localPosition = initialBossBarPosition;

        damagedBar.SetActive(false);
    }
}
