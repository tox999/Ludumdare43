using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotor : MonoBehaviour {

    [SerializeField]
    Vector3 rotation;
    [SerializeField]
    Vector3 axis = new Vector3(0, 0, 1);
    [SerializeField]
    float anglePerStep = 1f;
    [SerializeField]
    float rotationSpeed = 1.1f;

	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(axis, anglePerStep * Time.deltaTime * rotationSpeed);
	}
}
