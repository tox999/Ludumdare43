using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatenByFish : MonoBehaviour {

    [SerializeField] float time = 3f;


    private ObjectsInSea objectsInSea;

    private void Awake()
    {
        objectsInSea = GetComponentInParent<ObjectsInSea>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 16)
        {
            StartCoroutine(SlowDeath());
        }
    }

    IEnumerator SlowDeath()
    {
        yield return new WaitForSeconds(time);
        objectsInSea.catsInSea.Remove(gameObject);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
