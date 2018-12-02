using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    public Stats islandStats;
    [SerializeField]
    Mimics mimics;

    public float currentHP;
    [Range(0,1)] public float currentWeightPercent;

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
        else if (currentHP <= (currentHP * 0.5f))
            mimics.ChangeFace("shocked");

        CheckMaxWeight();
    }

    public void IslandDeath()
    {
        game.EndGame();   
    }

    private void CheckMaxWeight()
    {
        currentWeightPercent = catsOnIsland.weightOfAllCatsOnIsland / islandStats.maxWeight;
        if (currentWeightPercent >= 1)
        {
            game.EndGame();
        }
    }

}
