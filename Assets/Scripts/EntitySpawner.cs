using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EntitySpawner : MonoBehaviour
{
    [Header("Entities")]
    public GameObject entity;

    [Header("Spawn time")]
    public int minSpawnTime = 1;
    public int maxSpawnTime = 5;

    private bool shouldSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (shouldSpawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime + 1));
            Instantiate(entity, transform.position, Quaternion.identity);
        }
    }
}
