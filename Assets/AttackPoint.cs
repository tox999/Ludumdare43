using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    public GameObject attackPointRendered;
    RaycastHit2D ObjectHitByMouseRaycast;

    [SerializeField] LayerMask[] acceptableLayerMasks;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        foreach (LayerMask layerMask in acceptableLayerMasks)
        {
            if (Physics2D.Raycast(ray.origin, ray.direction, 2000, layerMask.value))
            {
                
                if (Input.GetMouseButtonDown(0))
                {
                    if (attackPointRendered.activeSelf == false)
                    {
                        attackPointRendered.SetActive(true);
                    }
                    attackPointRendered.transform.position = MousePositionInWorldPoints();
                }
            }
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