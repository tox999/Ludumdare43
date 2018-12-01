using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAttack : MonoBehaviour {

    //[SerializeField] float enemyDamage = 10f;
    //[SerializeField] float attackSpeed = 3f;
    [SerializeField] float time = 3f;
    [SerializeField] int catLayer = 18;
    [SerializeField] int legLayer = 16;

    GameObject attactedObject;
    ObjectsInSea objectsInSea;

    private void Start()
    {
        GameObject fish = gameObject.transform.parent.gameObject;
        GameObject fishSpawner = fish.transform.parent.gameObject;
        objectsInSea = fishSpawner.GetComponentInParent<ObjectsInSea>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == catLayer)
        {
            attactedObject = collision.gameObject;
            StartCoroutine(SlowDeath());
        }
    }

    IEnumerator SlowDeath()
    {
        yield return new WaitForSeconds(time);
        if (attactedObject != null)
        {
            objectsInSea.catsInSea.Remove(attactedObject);
            Destroy(attactedObject.transform.parent.gameObject);
        }
        GetComponentInParent<EnemyChaseBehaviour>().InitializeFish();
    }
}
