using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCat : MonoBehaviour
{
    [SerializeField] int catLayer = 18;
    GameObject catObject;
    ObjectsInSea objectsInSea;
    Island island;
    float islandMaxHP;

    private void Awake()
    {
        objectsInSea = FindObjectOfType<ObjectsInSea>();
        island = FindObjectOfType<Island>().GetComponent<Island>();
        islandMaxHP = island.islandStats.HP;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == catLayer)
        {
            catObject = collision.gameObject;
            if (island.currentHP < islandMaxHP)
            {
                KillCat();
                HealIsland();
                //ChangeIslandMimics();
            }

        }
    }

    private void KillCat()
    {
        if (catObject != null)
        {
            CatAttack catScript = catObject.GetComponent<CatAttack>();
            GameObject deathParticle = Instantiate(catScript.catDeathParticle, catScript.transform.position, Quaternion.identity);
            Destroy(deathParticle, 3);
            CatDeath();
        }
    }

    private void CatDeath()
    {
        if (catObject != null)
        {
            if (objectsInSea.catsInSea.Contains(catObject))
            {
                objectsInSea.RemoveCatFromSea(catObject);
            }
            Destroy(catObject.transform.parent.gameObject);
        }
    }

           
    private void HealIsland()
    {
        if (catObject != null)
        {
            island.currentHP += catObject.GetComponent<CatAttack>().catStats.heal;
            if (island.currentHP > islandMaxHP)
            {
                island.currentHP = islandMaxHP;
            }
        }
    }






}
