using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAttack : MonoBehaviour {

    [SerializeField] Stats fishStats;

    [SerializeField] int catLayer = 18;
    [SerializeField] int legLayer = 16;

    GameObject attactedObject;
    ObjectsInSea objectsInSea;
    bool isAttacking = false;

    private void Start()
    {
        GameObject fish = gameObject.transform.parent.gameObject;
        GameObject fishSpawner = fish.transform.parent.gameObject;
        objectsInSea = fishSpawner.GetComponentInParent<ObjectsInSea>();
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
            }
        }
        yield return new WaitForSeconds(fishStats.attackSpeed);
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
