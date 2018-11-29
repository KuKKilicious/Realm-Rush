using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
 
    [SerializeField][Range(0.1f,2f)]
    float waitBetweenTurns = 1f;
	// Use this for initialization
	void Start () {
        Pathfinder pathFinder = FindObjectOfType<Pathfinder>();
        var path = pathFinder.getPath();
        StartCoroutine(FollowPath(path));

    }
    
    private IEnumerator FollowPath(List<Waypoint> path) {
        foreach (Waypoint waypoint in path) {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitBetweenTurns);
        }
    }
    



    // Update is called once per frame
    void Update () {
		
	}
}
