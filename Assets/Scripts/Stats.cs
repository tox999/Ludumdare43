using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats")]
public class Stats : ScriptableObject
{
    public float HP;

    public float damage;

    public float attackSpeedMin;

    public float attackSpeedMax;

    public float attackRange;
        
    public float projectileSpeedMin;

    public float projectileSpeedMax;

    public float weight;

    public float maxWeight;
}
