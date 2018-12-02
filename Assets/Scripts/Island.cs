using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    public Stats islandStats;
    [SerializeField]
    Mimics mimics;

    public float currentHP;

    Game game;

    private void Awake()
    {
        currentHP = islandStats.HP;
        game = FindObjectOfType<Game>();
    }
    
    private void Update()
    {
        if (currentHP <= (currentHP * 0.2f))
            mimics.ChangeFace("tired");
        else if (currentHP > (currentHP * 0.2f))
            mimics.ChangeFace("default");

    }

    public void IslandDeath()
    {
        //Debug.Log("Island was eaten by fish! GAME OVER");
        
        game.PauseGame();
        
    }
}
