using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;

    public GameObject attackPrefab;

    public Transform[] slots;
    public Material[] slotsMat;

    private int slotObjective;

    public float lockCooldown;

    public EnemyStats enemyStats;

    private bool isCharging = false;

    private float attackProgress;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(DetectPlayer), lockCooldown, lockCooldown);

        foreach (Material material in slotsMat)
        {
            material.color = Color.white;
        }
    }

    private void DetectPlayer()
    {
        if (isCharging)
        {
            return;
        }

        float minDistance = Mathf.Infinity;

        if (player != null)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                float distance = Vector3.Distance(player.position, slots[i].position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    slotObjective = i;
                }
            }
        }
        if (player != null)
        {
            StartCoroutine(ChargedAttack(slotObjective));
        }
    }

    private System.Collections.IEnumerator ChargedAttack(int index)
    {
        isCharging = true;
        attackProgress = 0f;

        // Recognize the OG color of slot
        Material targetMaterial = slotsMat[index];
        Color originalColor = targetMaterial.color;
        Color redColor = Color.red;

        // Gradual change between white and red color from slot
        while (attackProgress < 1f)
        {
            attackProgress += Time.deltaTime / enemyStats.atkSpeed;
            targetMaterial.color = Color.Lerp(originalColor, redColor, attackProgress);
            yield return null;
        }

        Instantiate(attackPrefab, slots[index]);

        // Restore slot color
        yield return new WaitForSeconds(0.5f);
        targetMaterial.color = originalColor;

        isCharging = false;
    }
}
