using System.Collections;
using System.Collections.Generic;
using AC;
using TMPro;
using UnityEngine;

public class Traducao : MonoBehaviour
{
    public string Texto;
    public string Espanhol;
    public string Frances;
    public string Ingles;
    public string Alemao;
    public bool gameRunning=false;
    // Start is called before the first frame update
    public string traduzir(){
        int lingua = Options.GetLanguage();
        if(lingua == 0)
            return Espanhol;
        else if(lingua == 1)
            return Frances;
        else if(lingua==2)
            return Ingles;
        else
            return Alemao;
    }
    void Update(){
        if(!gameRunning)
            GetComponentInChildren<TextMeshPro>().text = traduzir();
    }
}
