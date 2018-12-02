using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    public Stats islandStats;

    public float currentHP;

    private void Awake()
    {
        currentHP = islandStats.HP;
    }

    public void IslandDeath()
    {
        Debug.Log("Island was eaten by fish! GAME OVER");
    }
}
