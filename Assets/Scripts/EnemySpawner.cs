using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
    [SerializeField]
    float secendsBetweenSpawns = 2f;
    [SerializeField]
    EnemyMovement enemyToSpawn;
    [SerializeField]
    int amountOfEnemiesToSpawn = 12;

    int enemiesSpawned = 0;
    [SerializeField]
    Text scoreText;
    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnEnemyEachSeconds(secendsBetweenSpawns));
        scoreText.text = enemiesSpawned.ToString();
    }

    private IEnumerator SpawnEnemyEachSeconds(float secendsBetweenSpawns) {
        while (true) {
        Instantiate(enemyToSpawn,transform.position,Quaternion.identity,transform);
            IncreaseScore();
            yield return new WaitForSeconds(secendsBetweenSpawns); 
        }

        //for (int i = 0; i < amountOfEnemiesToSpawn; i++) {} //todo: think about forever spawning vs waves
    }

    private void IncreaseScore() {
        enemiesSpawned++;
        scoreText.text = enemiesSpawned.ToString();
    }
}
