using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCursor : MonoBehaviour {

    Vector3 mousePosition;
    float lookSpeed = 1f;
    [SerializeField]
    Transform tongueRoot;
    LineRenderer lineRenderer;


    //private void Start()
    //{
    //    mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    mousePosition.z = 0;

    //    // Get Angle in Radians
    //    float AngleRad = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x);
    //    // Get Angle in Degrees
    //    float AngleDeg = (180 / Mathf.PI) * AngleRad;
    //    // Rotate Object
    //    transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    //}

    //private void Update()
    //{
    //    mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    mousePosition.z = 0;

    //    StretchBetween(tongueRoot.position, mousePosition);
    //    LookAt();
    //}

    void LookAt()
    {
        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180/ Mathf.PI) * AngleRad;
        // Rotate Object
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg+90);
    }

    void StretchBetween(Vector3 root, Vector3 target)
    {
        Vector3 startPos = root;
        Vector3 endPos = target;
        Vector3 centerPos = new Vector3(startPos.x + endPos.x, startPos.y + endPos.y, 0) / 2;

        //float scaleX = Mathf.Abs(startPos.x - endPos.x);
        float scaleY = Mathf.Abs(centerPos.y - endPos.y);

        //centerPos.x -= 0.5f;
        //centerPos.y += 0.5f;
        transform.position = startPos;
        transform.localScale = new Vector3(1, scaleY, 1);
    }


    // Creates a line renderer that follows a Sin() function
    // and animates it.



    void Awake()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        //float alpha = 1.0f;
        //Gradient gradient = new Gradient();
        //gradient.SetKeys(
        //    new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
        //    new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        //    );
        //lineRenderer.colorGradient = gradient;
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        //LookAt();
        DrawLine();
    }

    void DrawLine()
    {
        int lengthOfLineRenderer = Mathf.RoundToInt(Vector3.Distance(tongueRoot.position, mousePosition));
        lineRenderer.positionCount = lengthOfLineRenderer;

        var t = Time.time;
        Vector3 firstVertexPos = tongueRoot.position;
        Vector3 lastVertexPos = mousePosition;
        for (int i = 0; i < lengthOfLineRenderer; i++)
        {
            float x = i * Mathf.Lerp(firstVertexPos.x, lastVertexPos.x, t);
            //float y = Mathf.Sin(i + t);
            //float y = Mathf.Sin(i * Mathf.Lerp(firstVertexPos.y, lastVertexPos.y, t) + t);
            float y = Mathf.Sin(i * Mathf.Lerp(firstVertexPos.y, lastVertexPos.y, t));

            if (i < 10)
            {
                var tongueStart = new Vector3(firstVertexPos.x + i, y + i, 0.0f);
                lineRenderer.SetPosition(i, tongueStart);
            }
            else if (i >= lengthOfLineRenderer-10)
            {
                var tongueEnd = new Vector3(firstVertexPos.x + i, y + i, 0.0f);
                lineRenderer.SetPosition(i, tongueEnd);
            }

            lineRenderer.SetPosition(i, new Vector3(x, y, 0.0f));
        }
    }
}
