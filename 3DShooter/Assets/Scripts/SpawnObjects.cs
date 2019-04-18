using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject obj;
    public float beginSpawn = 5f;
    public float spawnTime = 10f;
    public Transform[] spawnPoints;


    void Start()
    {
        InvokeRepeating("Spawn", beginSpawn, spawnTime);
        int i;
        for (i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(obj, spawnPoints[i].position, spawnPoints[i].rotation);
        }

    }


    void Spawn()
    {
        if (PlayerVariable.currentHealth <= 0f)
        {
            Destroy(obj);
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        if(obj != null)
        {
            Instantiate(obj, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
}
