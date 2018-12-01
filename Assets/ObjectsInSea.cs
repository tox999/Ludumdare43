using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInSea : MonoBehaviour
{
    public List<GameObject> catsInSea;

    public delegate void NewCatInSea();
    public event NewCatInSea newCatInSea;

    public void AddCatToSea(GameObject cat)
    {
        catsInSea.Add(cat);
        newCatInSea();
    }
}
