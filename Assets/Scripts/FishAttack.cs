using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAttack : MonoBehaviour {

    [SerializeField] Stats fishStats;

    [SerializeField] int catLayer = 18;
    [SerializeField] int legLayer = 16;
    public float currentHP;

    GameObject attactedObject;
    ObjectsInSea objectsInSea;
    Island island;
    bool isAttacking = false;

    private void Awake()
    {
        objectsInSea = FindObjectOfType<ObjectsInSea>();
        island = FindObjectOfType<Island>();
        currentHP = fishStats.HP;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == catLayer)
        {
            attactedObject = collision.gameObject;
            if (!isAttacking)
            {
                isAttacking = true;
                StartCoroutine(AttackCat());
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == legLayer)
        {
            attactedObject = collision.gameObject;
            if (!isAttacking)
            {
                isAttacking = true;
                StartCoroutine(AttackIsland());
            }
        }
    }
            
    IEnumerator AttackCat()
    {
        if (attactedObject != null)
        {
            CatAttack cat = attactedObject.GetComponent<CatAttack>();
            cat.currentHP -= fishStats.damage;
            if (cat.currentHP <= 0)
            {
                isAttacking = false;
                CatDeath();
                StopCoroutine(AttackCat());
            }
        }
        yield return new WaitForSeconds(fishStats.attackSpeedMin);
        isAttacking = false;
    }

    IEnumerator AttackIsland()
    {
        if (attactedObject != null)
        {
            island.currentHP -= fishStats.damage;
            if (island.currentHP <= 0)
            {
                isAttacking = false;
                island.IslandDeath();
                StopCoroutine(AttackIsland());
            }
        }
        yield return new WaitForSeconds(fishStats.attackSpeedMin);
        isAttacking = false;
    }
    

    private void CatDeath()
    {
        if (attactedObject != null)
        {
            objectsInSea.RemoveCatFromSea(attactedObject);
            Destroy(attactedObject.transform.parent.gameObject);
        }
        GetComponentInParent<EnemyChaseBehaviour>().InitializeFish();
    }
}
