using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waving : MonoBehaviour
{

    [SerializeField]
    float speedY = 1;
    [SerializeField]
    float distanceY = 1;
    [SerializeField]
    float speedX = 1;
    [SerializeField]
    float distanceX = 1;

    
    void LateUpdate()
    {
        // Set the x position to loop between 0 and 3
        float x = Mathf.PingPong(Time.time * speedX, distanceX);
       
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
