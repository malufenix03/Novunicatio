using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float Speed;
    public string SomeString = "Esse é um teste";
    internal bool SomeSetting = true;
    public GameObject  SomeObject;
    void Update()
    {
        transform.Translate(0.5f*Time.deltaTime,0f,0f);
    }
}
