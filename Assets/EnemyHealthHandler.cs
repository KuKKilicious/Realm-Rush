using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthHandler : MonoBehaviour {
    [SerializeField]
    GameObject deathFX;
    [SerializeField]
    GameObject hitFX;
    [SerializeField]
    int waitUntilDestroy = 1;
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
        deathFX.SetActive(true);
        StartCoroutine(DestroyEnemyObject(waitUntilDestroy));
    }

    private IEnumerator DestroyEnemyObject(int wait) {
        yield return new WaitForSeconds(wait);
        Destroy(gameObject);
    }

    private void ProcessHits() {
        hits--;
        hitFX.GetComponent<ParticleSystem>().Play();
    }
}
