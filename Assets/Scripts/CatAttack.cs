using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAttack : MonoBehaviour
{
    public Stats catStats;
    public float currentHP;
    public bool canAttack = true;
    private bool catOnIsland = true;
    [SerializeField] int catsOnIslandLayer = 21;
    [SerializeField] GameObject harpoon;

    FishAttack nearestFish;
    GameObject pointToAttack;

    private void Start()
    {
        pointToAttack = FindObjectOfType<AttackPoint>().GetComponent<AttackPoint>().attackPointRendered;
        currentHP = catStats.HP;
    }

    private void Update()
    {
        if (canAttack)
        {
            //FindNearestFish();
            //AttackNearestFish();
            AttackPoint();
        }
    }

    /*
    private void FindNearestFish()
    {
        FishAttack[] allfishes = FindObjectsOfType<FishAttack>();
        if (allfishes.Length > 0)
        {
            float distanceToNerestFish = 0;
            foreach (FishAttack fish in allfishes)
            {
                float distanceToFish = (transform.position - fish.transform.position).magnitude;
                if (distanceToFish < catStats.attackRange)
                {
                    if (distanceToNerestFish == 0)
                    {
                        distanceToNerestFish = distanceToFish;
                        nearestFish = fish;
                    }
                    else if (distanceToFish < distanceToNerestFish)
                    {
                        distanceToNerestFish = distanceToFish;
                        nearestFish = fish;
                    }
                }
            }
        }
    }
    */

    private void AttackPoint()
    {
        if (pointToAttack.transform.position != new Vector3 (0,0,0) && pointToAttack.activeSelf)
        {
            StartCoroutine(ThrowHarpoon());
        }
    }

    /*   
    private void AttackNearestFish()
    {
        if (nearestFish != null)
        {
            StartCoroutine(ThrowHarpoon());
        }
    }
    */

    IEnumerator ThrowHarpoon()
    {
        canAttack = false;
        GameObject newHarpoon = Instantiate(harpoon, transform.position, Quaternion.identity);
        //Vector3 throwTarget = (nearestFish.transform.position);
        Vector3 throwTarget = pointToAttack.transform.position;
        newHarpoon.GetComponent<Harpoon>().SetTargetSpeedDamage(throwTarget, Random.Range(catStats.projectileSpeedMin, catStats.projectileSpeedMax), catStats.damage);
        yield return new WaitForSeconds(Random.Range(catStats.attackSpeedMin, catStats.attackSpeedMax));
        if (catOnIsland)
        {
            canAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == catsOnIslandLayer)
        {
            catOnIsland = false;
            canAttack = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == catsOnIslandLayer)
        {
            catOnIsland = true;
            canAttack = true;
        }
    }
}
