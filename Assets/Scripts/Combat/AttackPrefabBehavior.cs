using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPrefabBehavior : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 0.2f);
    }
}
