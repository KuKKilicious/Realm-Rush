﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    const int gridSize = 10;

    Vector2Int gridPos;
    // Use this for initialization

    public Vector2Int GetGridPos() {
        return new Vector2Int(
         Mathf.RoundToInt(transform.position.x / gridSize),
         Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }
    public int GetGridSize() {
        return gridSize;
    }
}