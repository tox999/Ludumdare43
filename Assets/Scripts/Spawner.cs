using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    WavesObject WavesObject;
    List<GameObject> spawningPoolOriginals;

    [SerializeField]
    string baseSpawnlingName;

    [SerializeField]
    bool oneFromPoolRandom = true;

    [SerializeField]
    int waveSize = 1;

    [SerializeField]
    GameObject spawnParent;

    [SerializeField]
    float spawnRandomRadius;

    [SerializeField]
    float spawningDelay = 1f;

    [HideInInspector]
    public List<GameObject> Spawns;

    [SerializeField]
    Vector3 spawnValues;

    [SerializeField]
    float spawnWait;

    [SerializeField]
    bool infiniteSpawning = false;

    int maxWaves;
    float startWait;
    float waveWait;
    int passedWaves = 0;
    Coroutine spawningCoroutine;
    List<Wave> waves;

    void Awake()
    {
        baseSpawnlingName = baseSpawnlingName ?? "Spawn";
        Spawns = new List<GameObject>();
        
        spawnParent = spawnParent ?? gameObject;
        waves = WavesObject.Waves;
        maxWaves = waves.Count;
        startWait = WavesObject.StartDelay;
        waveWait = WavesObject.DelayBetweenWaves;
    }

    // Use this for initialization
    void Start()
    {
        spawningCoroutine = StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        if (passedWaves >= maxWaves && spawningCoroutine != null && !infiniteSpawning)
            StopCoroutine(spawningCoroutine);
    }

    GameObject Spawn(GameObject original)
    {
        var x = Random.Range(-spawnValues.x, spawnValues.x) + spawnParent.transform.position.x;
        var y = Random.Range(-spawnValues.y, spawnValues.y) + spawnParent.transform.position.y;
        Vector3 spawnPosition = new Vector3(x, y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;

        GameObject SpawnInstance = Instantiate(original, spawnPosition, spawnRotation, spawnParent.transform);
        //GameObject SpawnInstance = Instantiate(original, spawnParent.transform);
        SpawnInstance.name = baseSpawnlingName + (Spawns.Count).ToString();
        Spawns.Add(SpawnInstance);
        return SpawnInstance;
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < waveSize; i++)
            {
                spawningPoolOriginals = waves[i].PrefabsToSpawn;
                if (oneFromPoolRandom)
                {
                    var original = spawningPoolOriginals[Random.Range(0, spawningPoolOriginals.Count)];             
                    Spawn(original);
                    yield return new WaitForSeconds(spawnWait);
                }
                else
                {
                    foreach(var original in spawningPoolOriginals)
                    { 
                        Spawn(original);
                        yield return new WaitForSeconds(spawnWait);
                    }
                }
            }

            passedWaves++;
            yield return new WaitForSeconds(waveWait);
        }
    }
}
