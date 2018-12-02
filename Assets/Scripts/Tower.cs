using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    //Parameters of each tower
    [SerializeField]
    Transform objectToPan;
    [SerializeField]
    float towerRange = 31f;
    public Waypoint baseWaypoint; //what the tower is standing on
    //State of each tower
    Transform targetEnemy;
    // Update is called once per frame
    void Update() {
        SetTargetEnemy();

        objectToPan.LookAt(targetEnemy);
        EnableEmission(enemyInRange());


    }

    private void SetTargetEnemy() {
        var sceneEnemies = FindObjectsOfType<EnemyHealthHandler>();
        if (sceneEnemies.Length <= 0) {
            return;
        }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyHealthHandler testEnemy in sceneEnemies) {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform closestEnemy, Transform testEnemy) {
        float distToClosestEnemy1 = Vector3.Distance(gameObject.transform.position, closestEnemy.position);
        float distToClosestEnemy2 = Vector3.Distance(gameObject.transform.position, testEnemy.position);

        if(distToClosestEnemy1 < distToClosestEnemy2) {
            return closestEnemy;
        }else {
            return testEnemy;
        }
    }

    private bool enemyInRange() {
        if (targetEnemy) {
            if (Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position) < towerRange) {
                Debug.Log("in range");
                return true;
            }
        }

        return false; //todo check if enemy is in range
    }

    private void EnableEmission(bool toEnable) {
        var emissionModule = objectToPan.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = toEnable;
    }
}
