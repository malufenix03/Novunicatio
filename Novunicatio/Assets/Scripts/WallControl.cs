using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour
{
    public Collider[] Walls;
    void Update(){
        var hasWalls = !Input.GetKey(KeyCode.Q);
        foreach (var wall in Walls){
            wall.enabled=hasWalls;
        }
    }
}
