using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersController : MonoBehaviour {
    float elapsedTimeInSeconds = 0f;
    static float spawnCooltimeInSeconds = 2f;
    SpawnPoint[] SpawnPoints;

	void Awake ()
    {
        SpawnPoints = GameObject.FindObjectsOfType<SpawnPoint>();
    }
	
	void Update ()
    {
        InstantiateSpawnAfterCooldownTimeInSeconds();
    }

    private void InstantiateSpawnAfterCooldownTimeInSeconds()
    {
        elapsedTimeInSeconds += Time.deltaTime;
        if (elapsedTimeInSeconds >= spawnCooltimeInSeconds)
        {
            elapsedTimeInSeconds = 0f;
            SpawnPoints[Random.Range(0, SpawnPoints.Length)].SpawnEnemy();
        }
    }
}
