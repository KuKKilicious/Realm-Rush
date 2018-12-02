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
    public bool isPlaceable = true;
  

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



    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(0) && isPlaceable) {
            
                PlaceTower();
            
        //If the mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse clicked Waypoint at:" + GetGridPos());

        }
    }

    private void PlaceTower() {
        FindObjectOfType<TowerFactory>().AddTower(this);
    }
}
