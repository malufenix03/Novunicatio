using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotateToggle : MonoBehaviour
{
    private bool mRotationState = true;
    // Esta variável mantém o controle do 
    //estado da rotação se ele está desligada ou ligada);

    public float Degrees = 100f;
    // Update is called once per frame
    void Update()
    {
        if(mRotationState)
            transform.Rotate(0f,Degrees*Time.deltaTime,0f);
            //transform.Translate(2f*Time.deltaTime,0f,0f);
    }
    void OnMouseDown(){
        mRotationState=!mRotationState;
        print("state = "+ mRotationState);
    }
}
