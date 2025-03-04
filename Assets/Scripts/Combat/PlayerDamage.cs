using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public PlayerStats playerStats;
    public EnemyLife enemyLife;

    public ComboManager comboManager;

    public float playerDmg;

    public void PlayerPhyAttack()
    {

        if (comboManager.inCombo)
        {
            playerDmg = playerStats.atk * playerStats.physicLvl * playerStats.critDmg;
        }
        else
        {
            playerDmg = playerStats.atk * playerStats.physicLvl;
        }
        
        enemyLife.TakeDamage();
    }

    public void PlayerIgnisAttack()
    {
        if (comboManager.inCombo)
        {
            playerDmg = playerStats.atk * playerStats.ignisLvl * playerStats.critDmg;
        }
        else
        {
            playerDmg = playerStats.atk * playerStats.ignisLvl;
        }
            
        enemyLife.TakeDamage();
    }

    public void PlayerSuiAttack()
    {
        if (comboManager.inCombo)
        {
            playerDmg = playerStats.atk * playerStats.suiLvl * playerStats.critDmg;
        }
        else
        {
            playerDmg = playerStats.atk * playerStats.suiLvl;
        }
        
        enemyLife.TakeDamage();
    }

    public void PlayerGlaciaAttack()
    {
        if (comboManager.inCombo)
        {
            playerDmg = playerStats.atk * playerStats.glaciaLvl * playerStats.critDmg;
        }
        else
        {
            playerDmg = playerStats.atk * playerStats.glaciaLvl;
        }
        
        enemyLife.TakeDamage();
    }

    public void PlayerTronoAttack()
    {
        if (comboManager.inCombo)
        {
            playerDmg = playerStats.atk * playerStats.tronoLvl * playerStats.critDmg;
        }
        else
        {
            playerDmg = playerStats.atk * playerStats.tronoLvl;
        }
        
        enemyLife.TakeDamage();
    }

    public void PlayerZashioAttack()
    {
        if (comboManager.inCombo)
        {
            playerDmg = playerStats.atk * playerStats.zashioLvl * playerStats.critDmg;
        }
        else
        {
            playerDmg = playerStats.atk * playerStats.zashioLvl;
        }
        
        enemyLife.TakeDamage();
    }

    public void PlayerTerraAttack()
    {
        if (comboManager.inCombo)
        {
            playerDmg = playerStats.atk * playerStats.terraLvl * playerStats.critDmg;
        }
        else
        {
            playerDmg = playerStats.atk * playerStats.terraLvl;
        }
        
        enemyLife.TakeDamage();
    }

    public void PlayerPhoroAttack()
    {
        if (comboManager.inCombo)
        {
            playerDmg = playerStats.atk * playerStats.phoroLvl * playerStats.critDmg;
        }
        else
        {
            playerDmg = playerStats.atk * playerStats.phoroLvl;
        }
        
        enemyLife.TakeDamage();
    }
}
