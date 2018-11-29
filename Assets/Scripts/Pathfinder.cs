using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    [SerializeField]
    Waypoint startPoint, endPoint;

    bool isRunning = true;
    Waypoint searchCenter; //current search center
    private List<Waypoint> path = new List<Waypoint>();
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> getPath() {
        LoadBlocks();

        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
        return path;
    }


    private void CreatePath() {
        path.Add(endPoint);
        Waypoint previous = endPoint.exploredFrom;
        while (previous != startPoint) {
            //add intermediate waypoints
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startPoint);
        path.Reverse();
    }

    private void BreadthFirstSearch() {
        queue.Enqueue(startPoint);
        while (queue.Count > 0 && isRunning) {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbors();
            searchCenter.isExplored = true;
        }
    }

    private void HaltIfEndFound() {
        if (searchCenter == endPoint) {
            isRunning = false;
        }
    }

    private void ExploreNeighbors() {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions) {
            Vector2Int explorationCoordinates = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(explorationCoordinates)) {
                QueueNewNeighbor(explorationCoordinates);
            }
        }

    }

    private void QueueNewNeighbor(Vector2Int explorationCoordinates) {
        Waypoint neighbor = grid[explorationCoordinates];
        if (!(neighbor.isExplored || queue.Contains(neighbor))) {
            neighbor.exploredFrom = searchCenter;
            queue.Enqueue(neighbor);
        }
    }

    private void QueueNewNeighbor() {
        throw new NotImplementedException();
    }

    private void ColorStartAndEnd() {
        startPoint.SetTopColor(Color.gray);
        endPoint.SetTopColor(Color.magenta);
    }

    private void LoadBlocks() {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints) {
            //overlapping blocks
            if (!grid.ContainsKey(waypoint.GetGridPos())) {
                //add to dictionary
                grid.Add(waypoint.GetGridPos(), waypoint);
                waypoint.SetTopColor(Color.black);
            } else {
                Debug.LogWarning("skipping Overlapping block" + waypoint.name + " at " + waypoint.GetGridPos());
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
