using System.Collections;
using System.Collections.Generic;
using DoorScript;
using Unity.VisualScripting;
using UnityEngine;


public class MousePick : MonoBehaviour
{
    private int mPicks=0;
    

    // Quando clica
    void OnMouseDown(){
        ++mPicks;
    }
}
