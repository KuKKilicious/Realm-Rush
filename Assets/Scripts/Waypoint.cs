using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//data class
public class Waypoint : MonoBehaviour {
    [SerializeField]
    Color exploredColor;
    public bool isExplored=false;
    public Waypoint exploredFrom;


    const int gridSize = 10;

    Vector2Int gridPos;
    // Use this for initialization

    private void Update() {
        if (isExplored) {
            SetTopColor(exploredColor);
        }
    }
    public Vector2Int GetGridPos() {
        return new Vector2Int(
         Mathf.RoundToInt(transform.position.x / gridSize),
         Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }
    public int GetGridSize() {
        return gridSize;
    }

    public void SetTopColor(Color color) {

        MeshRenderer topMeshRenderer = transform.Find("top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
