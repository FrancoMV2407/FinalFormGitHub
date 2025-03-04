using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public PlayerStats playerStats;

    public string bossName;
    public float maxLife;
    public int df;
    public float atkSpeed;
    public string atkType;
    public float evasion;
    public string resists;
    public string weak;

    public EnemyStats(string Name, float MaxLife, int Df, float AtkSpeed, string AtkType, float Evasion, string Resists, string Weak)
    {
        this.bossName = Name;
        this.maxLife = MaxLife;
        this.df = Df;
        this.atkSpeed = AtkSpeed;
        this.atkType = AtkType;
        this.evasion = Evasion;
        this.resists = Resists;
        this.weak = Weak;
    }
}
