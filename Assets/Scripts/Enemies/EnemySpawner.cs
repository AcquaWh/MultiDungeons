using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    float randX;
    Vector3 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time;
            randX = Random.Range(-8.4f, 8.4f);
        }
    }
}
