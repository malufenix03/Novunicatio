using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MousePick : MonoBehaviour
{
    private int mPicks=0;

    // Quando clica
    void OnMouseDown(){
        ++mPicks;
        Debug.Log("Este objeto foi escolhido " + mPicks + " vezes.");
    }
}
