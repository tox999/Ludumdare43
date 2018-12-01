using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObjectInSea : MonoBehaviour
{
    [SerializeField] LayerMask catLayerMask;

    private ObjectsInSea objectsInSea;

    private void Awake()
    {
        objectsInSea = GetComponentInParent<ObjectsInSea>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject newCatInSea = collision.gameObject;
        objectsInSea.AddCatToSea(newCatInSea);
    }
}
