using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waving : MonoBehaviour
{
    [SerializeField]
    float speedY = 1;
    [SerializeField]
    float distanceY = 0.001f;
    [SerializeField]
    float speedX = 1;
    [SerializeField]
    float distanceX = 1;
    float modifierY = 1;

    Vector3 lastPos;
    private void Start()
    {
        //lastPos = transform.position;
    }
    void LateUpdate()
    {
        
        // Set the x position to loop between 0 and 3
        float x = Mathf.PingPong(Time.time * speedX, distanceX);
        float y = transform.position.y;
        transform.position = new Vector3(x, y, transform.position.z);
        //modifierY *= -1;
        //lastPos = transform.position;

    }
}
