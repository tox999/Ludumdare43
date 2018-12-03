using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    public Stats islandStats;
    [SerializeField]
    Mimics mimics;

    float maxDrownY = -1.5f;
    float currentIslandYposition = 0;
    float drownSpeed = 0.05f;

    public float currentHP;
    [Range(0,1)] public float currentWeightPercent;

    float tooMuchWeigh1 = 0.3f;
    float tooMuchWeigh2 = 0.6f;
    float tooMuchWeigh3 = 0.9f;

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
        /*
        if (currentHP <= (currentHP * 0.2f))
            mimics.ChangeFace("tired");
        else if (currentHP <= (currentHP * 0.5f))
            mimics.ChangeFace("shocked");
        */
        ChangeMimimsByWeight();
        DrownWhenOverburdened();
        CheckMaxWeight();
    }

    private void ChangeMimimsByWeight()
    {
        if (currentWeightPercent <= tooMuchWeigh1)
        {
            mimics.ChangeCurrentFace("default");
        }
        else if (currentWeightPercent > tooMuchWeigh1 && currentWeightPercent <= tooMuchWeigh2)
        {
            mimics.ChangeCurrentFace("shock");
        }
        else if (currentWeightPercent > tooMuchWeigh2 && currentWeightPercent <= tooMuchWeigh3)
        {
            mimics.ChangeCurrentFace("tired");
        }
        else
        {
            mimics.ChangeCurrentFace("hurt");
        }
    }

    private void DrownWhenOverburdened()
    {
        currentIslandYposition =  maxDrownY * currentWeightPercent;
        Vector3 newPosition = new Vector3(transform.position.x, currentIslandYposition, transform.position.z);
        transform.position = Vector2.MoveTowards(transform.position, newPosition, drownSpeed * Time.deltaTime);
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
