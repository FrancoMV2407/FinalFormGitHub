using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerLife playerLife;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemyAttack"))
        {
            playerLife.TakeDamage();
        }
    }
}
