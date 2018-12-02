using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemyHP = 100f;
    [SerializeField] float enemyDamage = 10f;

    private Color enemyColor;

    public void GetDamage(float damage)
    {
        enemyHP -= damage;
        if (enemyHP <= 0)
        {
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        Destroy(this);
    }
}
