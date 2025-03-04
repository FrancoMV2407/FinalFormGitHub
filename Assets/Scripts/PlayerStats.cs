using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float atk;
    public float atkSpeed;
    public float evasion;
    public float stamina;
    public float staminaRecovery;
    public float adrenalineDuration;
    public float critDmg;

    public bool physicUnlock;
    public bool ignisUnlock;
    public bool suiUnlock;
    public bool glaciaUnlock;
    public bool tronoUnlock;
    public bool zashioUnlock;
    public bool terraUnlock;
    public bool phoroUnlock;

    public int physicLvl = 1;
    public int ignisLvl;
    public int suiLvl;
    public int glaciaLvl;
    public int tronoLvl;
    public int zashioLvl;
    public int terraLvl;
    public int phoroLvl;

    public int level;
    public int currentEXP = 0;
    public int levelRequirement;

    public ComboManager comboManager;

    public void LevelUp()
    {
        level++;
        currentEXP -= levelRequirement;
        levelRequirement += levelRequirement * 2;
    }

    void ComboMode()
    {
        if (comboManager.inCombo)
        {
            staminaRecovery += staminaRecovery;
        }
    }
}
