using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAttack : MonoBehaviour
{
    public Stats catStats;

    public float currentHP;

    private void Awake()
    {
        currentHP = catStats.HP;
    }

}
