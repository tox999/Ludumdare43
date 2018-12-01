using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Waves")]
public class WavesObject : ScriptableObject
{
    public List<Wave> Waves;
    
    public float StartDelay;
    public float DelayBetweenWaves;
}

[System.Serializable]
public class Wave
{   
    public List<GameObject> PrefabsToSpawn;
}
