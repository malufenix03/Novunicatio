using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public GameObject TargetA;
    public GameObject TargetB;
    public float Speed = Mathf.PI;

    void FixedUpdate(){
        var weight = (Mathf.Sin (Time.time * Speed)+1) * 0.5f;
        transform.position = TargetA.transform.position*weight + TargetB.transform.position * (1-weight);
    }

}
