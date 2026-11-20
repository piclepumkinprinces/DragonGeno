using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSpawner : MonoBehaviour
{
    public int minDragons;
    public int maxDragons;
    public int dragonCount;
    public float dragonSpawnRate;

    private List<GameObject> spawnedDragons = new List<GameObject>();

    public GameObject[] dragonPrefabs;

    private Transform dragonContainer;

    public bool spawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawn = true;


        GameObject containerObject = new GameObject("Spawned Dragons");
        dragonContainer = containerObject.transform;

        StartCoroutine(SpawnDragons());
    }

    // Update is called once per frame
    void Update()
    {
        spawnedDragons.RemoveAll(dragons => dragons == null);
        dragonCount = spawnedDragons.Count;

        if (dragonCount < maxDragons && !spawn)
        {
            spawn = true;

            StartCoroutine(SpawnDragons());
        }
    }

    IEnumerator SpawnDragons()
    {
        while (dragonCount < maxDragons)
        {
            Spawn();

            yield return new WaitForSeconds(dragonSpawnRate);
        }

        spawn = false;
    }

    void Spawn()
    {
        int randomDragon = Random.Range(0, dragonPrefabs.Length);

        GameObject newDragon = Instantiate(dragonPrefabs[randomDragon], transform.position, Quaternion.identity, dragonContainer);

        spawnedDragons.Add(newDragon);
        dragonCount = spawnedDragons.Count;
    }
}
