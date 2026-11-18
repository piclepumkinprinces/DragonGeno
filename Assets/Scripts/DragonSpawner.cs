using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSpawner : MonoBehaviour
{
    public int minDragons;
    public int maxDragons;
    public int dragonCount;
    public float dragonSpawnRate;

    public GameObject dragons;

    private List<GameObject> spawnedDragons = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnDragons());
    }

    // Update is called once per frame
    void Update()
    {
        spawnedDragons.RemoveAll(dragons => dragons == null);
        dragonCount = spawnedDragons.Count;

        if (dragonCount <= maxDragons)
        {
            StartCoroutine(SpawnDragons());
        }
    }

    IEnumerator SpawnDragons()
    {
        while (dragonCount <= maxDragons)
        {
            Spawn();

            yield return new WaitForSeconds(dragonSpawnRate);
        }
    }

    void Spawn()
    {
        GameObject newDragon = Instantiate(dragons, transform.position, Quaternion.identity);

        spawnedDragons.Add(newDragon);
        dragonCount = spawnedDragons.Count;
    }
}
