using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    [SerializeField]
    Transform objectToPan;
    [SerializeField]
    Transform targetEnemy;

    // Update is called once per frame
    void Update () {
        objectToPan.LookAt(targetEnemy);

        EnableEmission(enemyInRange());
        

	}

    private bool enemyInRange() {
        return true; //todo check if enemy is in range
    }

    private void EnableEmission(bool toEnable) {
        var emissionModule = objectToPan.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = toEnable;
    }
}
