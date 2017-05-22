using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    public GameObject enemyToSpawn;
    GameObject player;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
    public void SpawnEnemy()
    {
        Vector3 directionToTarget = player.transform.position - transform.position;
        float enemyStartingAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        Quaternion enemyStartRotation = Quaternion.AngleAxis(enemyStartingAngle, Vector3.forward);
        Instantiate(enemyToSpawn, transform.position, enemyStartRotation);

    }
}
