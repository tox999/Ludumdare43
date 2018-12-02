using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAttack : MonoBehaviour
{
    public Stats catStats;
    public float currentHP;
    public bool canAttack = true;
    [SerializeField] GameObject harpoon;

    FishAttack nearestFish;

    private void Start()
    {
        currentHP = catStats.HP;
    }

    private void Update()
    {
        if (canAttack)
        {
            FindNearestFish();
            AttackNearestFish();
        }
    }

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

    private void AttackNearestFish()
    {
        if (nearestFish !=null)
        {
            StartCoroutine(ThrowHarpoon());
        }
    }

    IEnumerator ThrowHarpoon()
    {
        canAttack = false;
        GameObject newHarpoon = Instantiate(harpoon, transform.position, Quaternion.identity);
        Vector3 throwTarget = (nearestFish.transform.position);
        newHarpoon.GetComponent<Harpoon>().SetTargetSpeedDamage(throwTarget, Random.Range(catStats.projectileSpeedMin, catStats.projectileSpeedMax), catStats.damage);
        yield return new WaitForSeconds(Random.Range(catStats.attackSpeedMin, catStats.attackSpeedMax));
        canAttack = true;
    }

}
