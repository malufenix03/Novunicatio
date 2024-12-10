using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Overlays;
using UnityEngine;
using AC;

[System.Serializable]
public class ListaTraducao{
    public string[] cores;
}

public class Layout{
    public int[,] layout;

    public Layout(int[,] cores){
        layout = cores;
    }
}

public class CoresChao : MonoBehaviour
{
    private string[] listaCores;
    public Material[] listaMateriais;
    private int[] numAparicao;
    public ListaTraducao[] listaTraducao = new ListaTraducao[3];
    public GameObject paiCores;
    public GameObject telaCor;
    private TextMeshPro textoCor;
    public GameObject[] telaTimer;
    private TextMeshPro textoTempo;
    private List<GameObject> pisos = new List<GameObject>();
    private int dificuldade;
    public Layout[] layouts;
    static public int pontos=0;
    private int round=0;
    public int roundMax=20;
    private bool isRunning = false;
    private bool isWaiting = false;
    private string cor;
    private string corTraduzida;
    public GameObject barreira;

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

        dificuldade =(int) PointsManager.fase;
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
                if(round == roundMax)
                    EndGame(1);
                else
                    NewRound();
            }
    }

    void StartGame(){
        telaCor.GetComponent<Traducao>().gameRunning = true;
        NewRound();
    }

    void createLayout(){
        // facil
        int[,] aux = { 
        { 1, 2, 3 },
        { 4, 5, 6 } };
        layouts[0].layout = aux;
    }
    void SelectLayout(){
        
    }

    void PaintLayout(Layout chao){
        int id=0;
        foreach (int cor in chao.layout ){
            pisos[id].GetComponent<MeshRenderer>().sharedMaterial = listaMateriais[cor];
        }
    }

    void Reset(){
        foreach (GameObject piso in pisos){
            piso.SetActive(true);
        }
        isWaiting = false;
    }
    void countPointsVictory(){
        pontos+=(dificuldade+1)*round;
            PointsManager.Ganhou((dificuldade+1)*round);
            if(dificuldade<4)
                PointsManager.fase+=1;
    }
    void countPointsDefeat(){
        pontos-=dificuldade*(roundMax-round);
            PointsManager.Perdeu(dificuldade*(roundMax-round));
    }
    void EndGame(int vitoria){
        Reset();
        telaCor.GetComponent<Traducao>().gameRunning = false;
        if(vitoria == 1){
            countPointsVictory();
        }
        else{
            countPointsDefeat();
        }
        MessageTimer("TurnOffTimer");
        textoCor.color = Color.white;
        barreira.GetComponent<Animator>().SetTrigger("endGameTrigger");
    }

    void NewRound(){
        Reset();
        isRunning =true;
        int aleatorio = Random.Range(0, ((dificuldade+1)*4 +1)%13);
        cor = listaCores[aleatorio];
        corTraduzida = Translate(aleatorio); 
        numAparicao[aleatorio]++;
        MessageTimer("TurnOnTimer",10);
        round++;
        textoCor.text = corTraduzida;
        if(numAparicao[aleatorio]<=2 && (aleatorio>dificuldade*4+1 || dificuldade==0)){
            textoCor.color=listaMateriais[aleatorio].color;
            textoCor.text += " ■";
        }
            
        else
            textoCor.color=Color.white;
        
    }
    void FinishRound(){
        foreach (GameObject piso in pisos){
            Material material = piso.GetComponent<MeshRenderer>().sharedMaterial;
            if(material.name!=cor){
                piso.SetActive(false);
            }

        }
        MessageTimer("TurnOnTimer",3);
        isWaiting=true;
        isRunning=false;
    }

    string Translate(int id){
        int lingua = Options.GetLanguage();
        return listaTraducao[lingua].cores[id];
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
