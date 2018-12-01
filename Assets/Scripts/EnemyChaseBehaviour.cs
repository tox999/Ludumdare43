using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseBehaviour : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] LayerMask legsLayerMask;
    [SerializeField] float chaseDistanceLimit = 0.5f;

    public Vector3 currentTarget;
    private ObjectsInSea objectsInSea;
    GameObject nearestCat;


    private void Awake()
    {
        nearestCat = new GameObject();
        GameObject fishSpawner = gameObject.transform.parent.gameObject;
        objectsInSea = fishSpawner.GetComponentInParent<ObjectsInSea>();
    }

    private void OnEnable()
    {
        objectsInSea.newCatInSea += GetNearestCat;
        objectsInSea.catOutOfSea += InitializeFish;
    }

    void Start()
    {
        InitializeFish();
    }

    private void GetNearestLeg()
    {
        RaycastHit2D nearestLeg = new RaycastHit2D();
        RaycastHit2D leftHit = Physics2D.Raycast(transform.position, Vector3.left, Mathf.Infinity, legsLayerMask.value);
        RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Vector3.right, Mathf.Infinity, legsLayerMask.value);

        
        if (leftHit.collider == null && rightHit.collider == null)
        {
            Debug.LogError("There are no legs to eat!!!");
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
        if ((transform.position - currentTarget).magnitude > chaseDistanceLimit)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
            transform.right = currentTarget - transform.position;
        }
    }

    private void GetNearestCat()
    {
        float nearestCatDistance = 0;
        foreach (GameObject cat in objectsInSea.catsInSea)
        {
            float distanceToCat = (transform.position - cat.transform.position).magnitude;
            if (nearestCatDistance == 0)
            {
                nearestCatDistance = distanceToCat;
                nearestCat = cat;
            }
            else if (distanceToCat < nearestCatDistance)
            {
                nearestCatDistance = distanceToCat;
                nearestCat = cat;
            }
        }
    }

    public void InitializeFish()
    {
        if (objectsInSea.catsInSea.Count > 0)
        {
            GetNearestCat();
        }
        else
        {
            GetNearestLeg();
        }
    }
    
    void Update()
    {
        ChaseTarget();

        if (objectsInSea.catsInSea.Count > 0)
        {
            if (nearestCat != null)
            {
                currentTarget = nearestCat.transform.position;
            }
            else
            {
                GetNearestCat();
            }
        }
    }

    private void OnDisable()
    {
        objectsInSea.newCatInSea -= GetNearestCat;
        objectsInSea.catOutOfSea -= InitializeFish;
    }
}
