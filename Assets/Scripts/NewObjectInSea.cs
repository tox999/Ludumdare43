using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObjectInSea : MonoBehaviour
{
    [SerializeField] int catLayer = 18;

    private ObjectsInSea objectsInSea;

    private void Awake()
    {
        objectsInSea = GetComponentInParent<ObjectsInSea>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == catLayer)
        {
            GameObject newCatInSea = collision.gameObject;
            objectsInSea.AddCatToSea(newCatInSea);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == catLayer)
        {
            GameObject catOutOfSea = collision.gameObject;
            objectsInSea.RemoveCatFromSea(catOutOfSea);
        }
    }

}
