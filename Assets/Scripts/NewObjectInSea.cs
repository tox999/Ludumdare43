using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObjectInSea : MonoBehaviour
{
    [SerializeField] int catLayer = 18;
    [SerializeField] float waterDrag = 7f;
    public bool mouseInSea;

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
            newCatInSea.GetComponent<Rigidbody2D>().drag = waterDrag;
            objectsInSea.AddCatToSea(newCatInSea);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == catLayer)
        {
            GameObject catOutOfSea = collision.gameObject;
            catOutOfSea.GetComponent<Rigidbody2D>().gravityScale = 1f;
            objectsInSea.RemoveCatFromSea(catOutOfSea);
        }
    }

    private void OnMouseEnter()
    {
        mouseInSea = true;
    }

    private void OnMouseExit()
    {
        mouseInSea = false;
    }
}
