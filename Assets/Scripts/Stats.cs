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

    public float mass;

    public float projectileSpeedMin;

    public float projectileSpeedMax;
}
