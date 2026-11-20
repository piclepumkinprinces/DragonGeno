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

    private Transform dragonContainer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject containerObject = new GameObject("Gespawnde_Objecten");
        dragonContainer = containerObject.transform;

        StartCoroutine(SpawnDragons());
    }

    // Update is called once per frame
    void Update()
    {
        spawnedDragons.RemoveAll(dragons => dragons == null);
        dragonCount = spawnedDragons.Count;
    }

    IEnumerator SpawnDragons()
    {
        while (dragonCount < maxDragons)
        {
            Spawn();

            yield return new WaitForSeconds(dragonSpawnRate);
        }
    }

    void Spawn()
    {
        GameObject newDragon = Instantiate(dragons, transform.position, Quaternion.identity, dragonContainer);

        spawnedDragons.Add(newDragon);
        dragonCount = spawnedDragons.Count;
    }
}
