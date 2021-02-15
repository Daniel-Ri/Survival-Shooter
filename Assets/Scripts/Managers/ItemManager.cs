using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public SpeedUp speedUpItem;
    public HealthUp healthUpItem;
    public float timeSpawnSpeedUp = 8f;
    public float timeSpawnHealthUp = 10f;
    public Transform[] spawnPoints;

    void Start()
    {
        Invoke("SpawnSpeedUp", timeSpawnSpeedUp);
        Invoke("SpawnHealthUp", timeSpawnHealthUp);
    }

    public void SpeedUpTaken()
    {
        Invoke("SpawnSpeedUp", timeSpawnSpeedUp);
    }

    public void HealthUpTaken()
    {
        Invoke("SpawnHealthUp", timeSpawnHealthUp);
    }

    public void SpawnSpeedUp()
    {
        Instantiate(speedUpItem, spawnPoints[0].position, spawnPoints[0].rotation);
    }

    public void SpawnHealthUp()
    {
        Instantiate(healthUpItem, spawnPoints[1].position, spawnPoints[1].rotation);
    }
}
