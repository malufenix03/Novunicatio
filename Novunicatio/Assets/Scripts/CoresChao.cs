using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CoresChao : MonoBehaviour
{
    private string[] listaCores;
    public Material[] listaMateriais;
    private int[] numAparicao;
    public string[] listaTraducao;
    public GameObject paiCores;
    public GameObject telaCor;
    private TextMeshPro textoCor;
    public GameObject[] telaTimer;
    private TextMeshPro textoTempo;
    private List<GameObject> pisos = new List<GameObject>();
    private int pontos=0;
    private int round=0;
    private bool isRunning = false;
    private bool isWaiting = false;
    private string cor;
    private string corTraduzida;
    // Start is called before the first frame update
    void Start()
    {
        listaCores = new string[listaMateriais.Length];
        numAparicao = new int[listaCores.Length];
        foreach (Transform child in paiCores.transform){
            pisos.Add(child.GameObject());
        }
        int id=0;
        foreach (Material nome in listaMateriais){
            listaCores[id++]=nome.name;
        }
        textoCor=telaCor.GetComponentInChildren<TextMeshPro>();
        textoTempo = telaTimer[0].GetComponentInChildren<TextMeshPro>();
    }
    // Update is called once per frame
    void Update()
    {
        if(isRunning)
            if(textoTempo.text == "0:00"){
                FinishRound();
            }
        if(isWaiting)
            if(textoTempo.text == "0:00"){
                NewRound();
            }
    }

    void StartGame(){
        NewRound();
        
    }

    void EndGame(){

    }

    void NewRound(){
        foreach (GameObject piso in pisos){
            piso.SetActive(true);
        }
        isWaiting = false;
        isRunning =true;
        int aleatorio = Random.Range(0,listaCores.Length);
        cor = listaCores[aleatorio];
        corTraduzida = listaTraducao[aleatorio];
        numAparicao[aleatorio]++;
        MessageTimer("TurnOnTimer",10);
        round++;
        textoCor.text = corTraduzida;
        if(numAparicao[aleatorio]<=2)
            textoCor.color=listaMateriais[aleatorio].color;
        
    }
    void FinishRound(){
        foreach (GameObject piso in pisos){
            Material material = piso.GetComponent<MeshRenderer>().sharedMaterial;
            if(material.name!=cor){
                piso.SetActive(false);
            }

        }
        MessageTimer("TurnOnTimer",2);
        isWaiting=true;
        isRunning=false;
    }

    void Translate(string lingua){

    }

    void MessageTimer(string message,int tempo){
        foreach (GameObject timer in telaTimer)
            timer.SendMessage(message,tempo);
    }
    void MessageTimer(string message){
        foreach (GameObject timer in telaTimer)
            timer.SendMessage(message);
    }
}
