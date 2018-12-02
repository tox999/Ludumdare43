using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void IslandLowHp();
    public static event IslandLowHp OnIslandLowHp;
    public delegate void IslandLowCarryCapacity();
    public static event IslandLowCarryCapacity OnIslandLowCarryCapacity;
    public delegate void IslandAte();
    public static event IslandAte OnIslandAte;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
