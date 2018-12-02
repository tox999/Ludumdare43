using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInSea : MonoBehaviour
{
    public List<GameObject> catsInSea;

    public delegate void NewCatInSea();
    public event NewCatInSea newCatInSea;

    public delegate void CatOutOfSea();
    public event CatOutOfSea catOutOfSea;


    public void AddCatToSea(GameObject cat)
    {
        catsInSea.Add(cat);
        if (newCatInSea != null)
        {
            newCatInSea();
        }
    }

    public void RemoveCatFromSea(GameObject cat)
    {
        catsInSea.Remove(cat);
        if (catOutOfSea != null)
        {
            catOutOfSea();
        }
    }
}
