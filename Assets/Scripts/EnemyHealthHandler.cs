﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthHandler : MonoBehaviour {
    [SerializeField]
    GameObject deathFX;
    [SerializeField]
    GameObject hitFX;
    [SerializeField]
    GameObject damageCastleFX;

    [SerializeField]
    int hits = 4;
    [SerializeField]
    Collider colliderMesh;
   

    private void OnParticleCollision(GameObject other) {
        ProcessHits();
        if (hits < 1) {
            StopMoving();
            KillEnemy();
        }
        Debug.Log("enemy hit");
    }

    private void StopMoving() {
        EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
        enemyMovement.StopMoving();
    }

    private void KillEnemy() {
        var fX = Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(fX,fX.GetComponent<ParticleSystem>().main.duration);
        Destroy(gameObject);
    }

    public void DamageCastle() {
        var fX = Instantiate(damageCastleFX, transform.position, Quaternion.identity);
        float destroyWaitTime = fX.GetComponent<ParticleSystem>().main.duration;
        Destroy(fX, destroyWaitTime);
        Destroy(gameObject,destroyWaitTime);
    }

    private void ProcessHits() {
        hits--;
        hitFX.GetComponent<ParticleSystem>().Play();
    }
}