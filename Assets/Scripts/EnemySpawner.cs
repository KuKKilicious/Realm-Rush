using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField]
    float secendsBetweenSpawns = 2f;
    [SerializeField]
    EnemyMovement enemyToSpawn;
    [SerializeField]
    int amountOfEnemiesToSpawn = 12;
    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnEnemyEachSeconds(secendsBetweenSpawns));
	}

    private IEnumerator SpawnEnemyEachSeconds(float secendsBetweenSpawns) {

        for (int i = 0; i < amountOfEnemiesToSpawn; i++) {
            Instantiate(enemyToSpawn,transform.position,Quaternion.identity,transform);
            yield return new WaitForSeconds(secendsBetweenSpawns); 
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
