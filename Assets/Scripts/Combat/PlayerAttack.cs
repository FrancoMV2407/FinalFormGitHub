using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerDamage playerDmg;
    public PlayerStats playerStats;
    public Stamina stamina;

    public float phyAtkCooldown = 1;
    private float phyAtkTime;

    public float ignisAtkCooldown = 1;
    private float ignisAtkTime;

    public float suiAtkCooldown = 1;
    private float suiAtkTime;

    public float glaciaAtkCooldown = 1;
    private float glaciaAtkTime;

    public float tronoAtkCooldown = 1;
    private float tronoAtkTime;

    public float zashioAtkCooldown = 1;
    private float zashioAtkTime;

    public float terraAtkCooldown = 1;
    private float terraAtkTime;

    public float phoroAtkCooldown = 1;
    private float phoroAtkTime;

    private void Start()
    {
        phyAtkCooldown = phyAtkCooldown * playerStats.atkSpeed;
        phyAtkTime = phyAtkCooldown;
    }

    void Update()
    {
        if (playerStats.physicUnlock)
        {
            if (Input.GetKeyDown(KeyCode.P) && phyAtkTime >= phyAtkCooldown && stamina.currentStamina >= stamina.phyAtkCost)
            {
                playerDmg.PlayerPhyAttack();
                stamina.PhyAttackStamina();
                phyAtkTime = 0;
            }

            if (phyAtkTime < phyAtkCooldown)
            {
                phyAtkTime += Time.deltaTime;
            }
        }

        if (playerStats.ignisUnlock)
        {
            if (Input.GetKeyDown(KeyCode.I) && ignisAtkTime >= ignisAtkCooldown && stamina.currentStamina >= stamina.ignisAtkCost)
            {
                playerDmg.PlayerIgnisAttack();
                stamina.IgnisAttackStamina();
                ignisAtkTime = 0;
            }

            if (ignisAtkTime < phyAtkCooldown)
            {
                ignisAtkTime += Time.deltaTime;
            }
        }

        if (playerStats.suiUnlock)
        {
            if (Input.GetKeyDown(KeyCode.U) && suiAtkTime >= suiAtkCooldown && stamina.currentStamina >= stamina.suiAtkCost)
            {
                playerDmg.PlayerSuiAttack();
                stamina.suiAttackStamina();
                suiAtkTime = 0;
            }

            if (suiAtkTime < suiAtkCooldown)
            {
                suiAtkTime += Time.deltaTime;
            }
        }

        if (playerStats.glaciaUnlock)
        {
            if (Input.GetKeyDown(KeyCode.L) && glaciaAtkTime >= glaciaAtkCooldown && stamina.currentStamina >= stamina.glaciaAtkCost)
            {
                playerDmg.PlayerGlaciaAttack();
                stamina.GlaciaAttackStamina();
                glaciaAtkTime = 0;
            }

            if (glaciaAtkTime < glaciaAtkCooldown)
            {
                glaciaAtkTime += Time.deltaTime;
            }
        }
        
        if (playerStats.tronoUnlock)
        {
            if (Input.GetKeyDown(KeyCode.O) && tronoAtkTime >= tronoAtkCooldown && stamina.currentStamina >= stamina.tronoAtkCost)
            {
                playerDmg.PlayerTronoAttack();
                stamina.TronoAttackStamina();
                tronoAtkTime = 0;
            }

            if (tronoAtkTime < tronoAtkCooldown)
            {
                tronoAtkTime += Time.deltaTime;
            }
        }

        if (playerStats.zashioUnlock)
        {
            if (Input.GetKeyDown(KeyCode.J) && zashioAtkTime >= zashioAtkCooldown && stamina.currentStamina >= stamina.zashioAtkCost)
            {
                playerDmg.PlayerZashioAttack();
                stamina.ZashioAttackStamina();
                zashioAtkTime = 0;
            }

            if (zashioAtkTime < zashioAtkCooldown)
            {
                zashioAtkTime += Time.deltaTime;
            }
        }

        if (playerStats.terraUnlock)
        {
            if (Input.GetKeyDown(KeyCode.H) && terraAtkTime >= terraAtkCooldown && stamina.currentStamina >= terraAtkCooldown)
            {
                playerDmg.PlayerTerraAttack();
                stamina.TerraAttackStamina();
                terraAtkTime = 0;
            }

            if (terraAtkTime < terraAtkCooldown)
            {
                terraAtkTime += Time.deltaTime;
            }
        }
        
        if (playerStats.phoroUnlock)
        {
            if (Input.GetKeyDown(KeyCode.K) && phoroAtkTime >= phoroAtkCooldown && stamina.currentStamina >= phoroAtkCooldown)
            {
                playerDmg.PlayerPhoroAttack();
                stamina.PhoroAttackStamina();
                phoroAtkTime = 0;
            }

            if (phoroAtkTime < phoroAtkCooldown)
            {
                phoroAtkTime += Time.deltaTime;
            }
        }
    }
}
