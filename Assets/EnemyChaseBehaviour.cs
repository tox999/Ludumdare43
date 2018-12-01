using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseBehaviour : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] LayerMask legsLayerMask;
    [SerializeField] float chaseDistanceLimit = 0.5f;

    private Vector3 currentTarget;

	void Start()
    {
        GetNearestLeg();
    }

    private void GetNearestLeg()
    {
        RaycastHit2D nearestLeg = new RaycastHit2D();
        RaycastHit2D leftHit = Physics2D.Raycast(transform.position, Vector3.left, Mathf.Infinity, legsLayerMask.value);
        RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Vector3.right, Mathf.Infinity, legsLayerMask.value);

        
        if (leftHit.collider == null && rightHit.collider == null)
        {
            Debug.LogError("There are no legs!!!");
        }
        else if (leftHit.collider != null && rightHit.collider != null)
        {
            if (leftHit.distance < rightHit.distance)
            {
                nearestLeg = leftHit;
            }
            else
            {
                nearestLeg = rightHit;
            }
        }
        else if (leftHit.collider != null)
        {
            nearestLeg = leftHit;
        }
        else
        {
            nearestLeg = rightHit;
        }
        currentTarget = nearestLeg.point;
    }


    private void ChaseTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        transform.right = currentTarget - transform.position;
    }


    
    void Update()
    {
        if ((transform.position - currentTarget).magnitude > chaseDistanceLimit)
        {
            ChaseTarget();
        }
    }
}
