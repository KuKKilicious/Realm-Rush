using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();



    // Use this for initialization
    void Start() {
        LoadBlocks();


    }

    private void LoadBlocks() {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints) {
            //overlapping blocks
            if (!grid.ContainsKey(waypoint.GetGridPos())) {
                //add to dictionary
                grid.Add(waypoint.GetGridPos(), waypoint);
            } else {
                Debug.LogWarning("skipping Overlapping block" + waypoint.name + " at " + waypoint.GetGridPos());
            }
        }
        Debug.Log("loaded" + grid.Count + "blocks");
    }

    // Update is called once per frame
    void Update() {

    }
}
