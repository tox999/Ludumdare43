using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAttack : MonoBehaviour {

    [SerializeField] Stats fishStats;
    public GameObject fishDamageParticle;
    public GameObject fishDeathParticle;

    [SerializeField] int catLayer = 18;
    [SerializeField] int legLayer = 16;
    public float currentHP;

    GameObject attactedObject;
    ObjectsInSea objectsInSea;
    Island island;
    bool isAttacking = false;

    SpriteSwitcher sswitcher;
    
    private void Awake()
    {
        objectsInSea = FindObjectOfType<ObjectsInSea>();
        island = FindObjectOfType<Island>();
        currentHP = fishStats.HP;
        sswitcher = GetComponent<SpriteSwitcher>();
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
        sswitcher.ChangeSprite("attack");
        if (attactedObject != null)
        {
            CatAttack cat = attactedObject.GetComponent<CatAttack>();
            cat.currentHP -= fishStats.damage;
            GameObject damageParticle = Instantiate(cat.catDamageParticle, cat.transform.position, Quaternion.identity);
            Destroy(damageParticle, 3);
            if (cat.currentHP <= 0)
            {
                isAttacking = false;
                GameObject deathParticle = Instantiate(cat.catDeathParticle, cat.transform.position, Quaternion.identity);
                Destroy(deathParticle, 3);
                CatDeath();
                StopCoroutine(AttackCat());
            }
        }
        yield return new WaitForSeconds(fishStats.attackSpeedMin);
        isAttacking = false;
        sswitcher.ChangeSprite("default");
    }

    IEnumerator AttackIsland()
    {
        sswitcher.ChangeSprite("attack");
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
        sswitcher.ChangeSprite("default");
    }
    

    private void CatDeath()
    {
        if (attactedObject != null)
        {
            attactedObject.GetComponent<SpriteSwitcher>().ChangeSprite("dead");
            objectsInSea.RemoveCatFromSea(attactedObject);
            Destroy(attactedObject.transform.parent.gameObject);
        }
        GetComponentInParent<EnemyChaseBehaviour>().InitializeFish();
    }
}
