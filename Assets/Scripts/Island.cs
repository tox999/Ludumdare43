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
    CountCatsOnIsland catsOnIsland;

    private void Awake()
    {
        currentHP = islandStats.HP;
        game = FindObjectOfType<Game>();
        catsOnIsland = FindObjectOfType<CountCatsOnIsland>();
    }
    
    private void Update()
    {
        if (currentHP <= (currentHP * 0.2f))
            mimics.ChangeFace("tired");
        else if (currentHP > (currentHP * 0.2f))
            mimics.ChangeFace("default");
        CheckMaxWeight();
    }

    public void IslandDeath()
    {
        game.EndGame();   
    }

    private void CheckMaxWeight()
    {
        if (catsOnIsland.weightOfAllCatsOnIsland >= islandStats.maxWeight)
        {
            Debug.Log("Island is overloaded with cats!!!");
            game.EndGame();
        }
    }

}
