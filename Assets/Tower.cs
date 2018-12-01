using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    [SerializeField]
    Transform objectToPan;
    [SerializeField]
    Transform targetEnemy;
    [SerializeField]
    float towerRange = 31f;

    // Update is called once per frame
    void Update() {
        objectToPan.LookAt(targetEnemy);

        EnableEmission(enemyInRange());


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
