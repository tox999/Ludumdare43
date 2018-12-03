using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    public GameObject attackPointRendered;
    NewObjectInSea newObjectInSea;

    private void Start()
    {
        newObjectInSea = FindObjectOfType<NewObjectInSea>();
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && newObjectInSea.GetComponent<NewObjectInSea>().mouseInSea)
        {
            if (attackPointRendered.activeSelf == false)
            {
                attackPointRendered.SetActive(true);
            }
            attackPointRendered.transform.position = MousePositionInWorldPoints();
        }
    }
 
    private Vector3 MousePositionInWorldPoints()
    {
        Vector3 mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }
}

