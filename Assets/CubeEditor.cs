﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour {

    [SerializeField][Range(1f,20f)]
    float gridSize = 10f;

    TextMesh textMesh;
    
    // Update is called once per frame
    void Update () {
      

        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.y = 0f;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = snapPos;
        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = "("+snapPos.x/gridSize+","+snapPos.z/gridSize+")";
    }


}