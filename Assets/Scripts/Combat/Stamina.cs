using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Image fillBar;

    public PlayerStats playerStats;
    public float currentStamina;

    public float moveCost = 5;
    public float phyAtkCost = 3;
    public float ignisAtkCost = 4;
    public float suiAtkCost = 2;
    public float glaciaAtkCost = 3;
    public float tronoAtkCost = 5;
    public float zashioAtkCost = 2;
    public float terraAtkCost = 3;
    public float phoroAtkCost = 5;


    // Start is called before the first frame update
    void Start()
    {
        currentStamina = playerStats.stamina;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentStamina < playerStats.stamina)
        {
            currentStamina += playerStats.staminaRecovery * Time.deltaTime;
        }

        if(currentStamina < 0)
        {
            currentStamina = 0;
        }

        float  normalizeStamina = currentStamina / playerStats.stamina;
        fillBar.fillAmount = normalizeStamina;
    }

    public void MoveStamina()
    {
        currentStamina -= moveCost;
    }

    public void PhyAttackStamina()
    {
        currentStamina -= phyAtkCost;
    }

    public void IgnisAttackStamina()
    {
        currentStamina -= ignisAtkCost;
    }

    public void suiAttackStamina()
    {
        currentStamina -= suiAtkCost;
    }

    public void GlaciaAttackStamina()
    {
        currentStamina -= glaciaAtkCost;
    }

    public void TronoAttackStamina()
    {
        currentStamina -= tronoAtkCost;
    }

    public void ZashioAttackStamina()
    {
        currentStamina -= zashioAtkCost;
    }

    public void TerraAttackStamina()
    {
        currentStamina -= terraAtkCost;
    }

    public void PhoroAttackStamina()
    {
        currentStamina -= phoroAtkCost;
    }
}
