using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma strict
public class spawnEnemy : MonoBehaviour
{
    private float timer = 0f;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0.0f, 5f);

    }

    // Update is called once per frame
    void Update()
    {
    }

    void Spawn()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-100, 110), 5, Random.Range(-100, 110));

        Instantiate(enemy, randomSpawnPosition, Quaternion.identity);

    }
}