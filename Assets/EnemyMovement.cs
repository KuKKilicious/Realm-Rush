using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField]
    List<Waypoint> path;
    [SerializeField][Range(0.1f,2f)]
    float waitBetweenTurns = 1f;
	// Use this for initialization
	void Start () {
        
        StartCoroutine(FollowPath());
        


    }

    private IEnumerator FollowPath() {
        foreach (Waypoint waypoint in path) {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitBetweenTurns);
        }
    }




    // Update is called once per frame
    void Update () {
		
	}
}
