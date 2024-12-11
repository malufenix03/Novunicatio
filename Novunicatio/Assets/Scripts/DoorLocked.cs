using System.Collections;
using System.Collections.Generic;
using DoorScript;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class DoorLocked : MonoBehaviour
{
    private bool saiuDialogo = false;
    public string funcao;
    // Quando clica
    void OnMouseDown(){
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        if(!saiuDialogo){
            SendMessage(funcao,-1);
            saiuDialogo = true;
        }
            
    }
}
