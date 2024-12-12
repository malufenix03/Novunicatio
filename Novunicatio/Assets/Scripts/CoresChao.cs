using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using AC;

[System.Serializable]
public class ListaTraducao{
    public string[] cores;
}

[System.Serializable]
public class Layout{
    public int[,] layout;

    public Layout(){

    }
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
    private Timer timer;
    private List<GameObject> pisos = new List<GameObject>();
    private int dificuldade;
    public Layout[] layouts;
    static public int pontos=0;
    private int round=0;
    public int[] roundMax= new int[5]{10,20,20,20,20};
    private bool isRunning = false;
    private bool isWaiting = false;
    private string cor;
    private string corTraduzida;
    public GameObject barreira;
    private int numLayouts=13;

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
        timer = telaTimer[0].GetComponentInChildren<Timer>();

        dificuldade =(int) PointsManager.fase;
    }
    // Update is called once per frame
    void Update()
    {
        if(isRunning)
            if(timer.TimeRemaining <= 0){
                FinishRound();
            }
        if(isWaiting)
            if(timer.TimeRemaining <= 0){
                if(round == roundMax[dificuldade])
                    EndGame(1);
                else
                    NewRound();
            }
    }

    void StartGame(){
        createAllLayout();
        telaCor.GetComponent<Traducao>().gameRunning = true;
        NewRound();
    }
    
    void createLayout(int num){

    }

    void createAllLayout(){
        layouts = new Layout[numLayouts];
        for (int i=0;i<numLayouts;i++)
            layouts[i] = new Layout();
        // facil
        layouts[0].layout = new int[,]{ 
        { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
        { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
        { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
        { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
        { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4},
        { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4},
        { 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0},
         };
         layouts[1].layout = new int[,]{ 
        { 4, 4, 2, 2, 2, 3, 3, 3, 2, 2, 2, 4, 4},
        { 4, 4, 2, 2, 2, 0, 3, 0, 2, 2, 2, 4, 4},
        { 2, 2, 3, 3, 0, 0, 0, 0, 0, 3, 3, 2, 2},
        { 2, 2, 3, 3, 0, 0, 0, 0, 0, 3, 3, 2, 2},
        { 2, 2, 0, 0, 0, 0, 1, 0, 0, 0, 0, 2, 2},
        { 0, 0, 0, 0, 0, 1, 4, 1, 0, 0, 0, 0, 0},
        { 0, 0, 0, 0, 0, 1, 4, 1, 0, 0, 0, 0, 0},
        { 2, 2, 0, 0, 0, 0, 1, 0, 0, 0, 0, 2, 2},
        { 2, 2, 3, 3, 0, 0, 0, 0, 0, 3, 3, 2, 2},
        { 2, 2, 3, 3, 0, 0, 0, 0, 0, 3, 3, 2, 2},
        { 4, 4, 2, 2, 2, 0, 3, 0, 2, 2, 2, 4, 4},
        { 4, 4, 2, 2, 2, 3, 3, 3, 2, 2, 2, 4, 4},
         };
         layouts[2].layout = new int[,] {
        { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
        { 0, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 0 },
        { 1, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2, 1 },
        { 1, 2, 3, 4, 4, 4, 4, 4, 4, 4, 3, 2, 1 },
        { 1, 2, 3, 4, 4, 4, 4, 4, 4, 4, 3, 2, 1 },
        { 1, 2, 3, 4, 4, 4, 4, 4, 4, 4, 3, 2, 1 },
        { 1, 2, 3, 4, 4, 4, 4, 4, 4, 4, 3, 2, 1 },
        { 1, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2, 1 },
        { 1, 2, 3, 2, 2, 2, 2, 2, 2, 2, 3, 2, 1 },
        { 0, 1, 2, 1, 1, 1, 1, 1, 2, 1, 2, 1, 0 },
        { 0, 1, 2, 1, 1, 1, 1, 1, 2, 1, 2, 1, 0 },
        { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 }
        };
        layouts[3].layout = new int[,] {
        { 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4 },
        { 0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4 },
        { 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 4, 4 },
        { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4 },
        { 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4 },
        { 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4 },
        { 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4 },
        { 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 },
        { 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3 },
        { 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 3, 3 },
        { 2, 3, 4, 4, 4, 4, 4, 4, 4, 3, 3, 3, 2 },
        { 2, 2, 3, 3, 3, 3, 3, 3, 3, 2, 2, 2, 2 }
        };
        layouts[4].layout = new int[,] {
        { 0, 1, 1, 2, 2, 3, 3, 4, 4, 3, 2, 1, 0 },
        { 1, 0, 1, 2, 2, 3, 3, 4, 4, 3, 2, 1, 0 },
        { 1, 2, 0, 3, 3, 4, 4, 3, 2, 1, 1, 2, 0 },
        { 2, 3, 4, 0, 1, 2, 3, 4, 3, 3, 1, 2, 4 },
        { 2, 2, 3, 4, 0, 1, 3, 4, 3, 2, 1, 0, 4 },
        { 3, 4, 4, 3, 0, 1, 2, 4, 4, 3, 2, 1, 0 },
        { 4, 4, 3, 4, 0, 1, 3, 4, 3, 2, 1, 0, 4 },
        { 3, 3, 2, 4, 0, 1, 2, 3, 4, 3, 2, 1, 0 },
        { 4, 4, 4, 0, 1, 2, 3, 3, 2, 1, 0, 3, 4 },
        { 1, 2, 3, 3, 4, 0, 1, 4, 2, 3, 0, 2, 1 },
        { 3, 4, 2, 1, 3, 0, 2, 4, 1, 2, 4, 3, 1 },
        { 2, 2, 3, 3, 1, 0, 4, 3, 2, 4, 1, 0, 2 }
        };

        //minimo

        layouts[5].layout = new int[,] {
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6 },
        { 1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 7, 6, 5 },
        { 2, 1, 0, 1, 2, 3, 4, 5, 6, 7, 6, 5, 4 },
        { 3, 2, 1, 0, 1, 2, 3, 4, 5, 6, 5, 4, 3 },
        { 4, 3, 2, 1, 0, 1, 2, 3, 4, 5, 4, 3, 2 },
        { 5, 4, 3, 2, 1, 0, 1, 2, 3, 4, 3, 2, 1 },
        { 6, 5, 4, 3, 2, 1, 0, 1, 2, 3, 2, 1, 0 },
        { 7, 6, 5, 4, 3, 2, 1, 0, 1, 2, 1, 0, 9 },
        { 8, 7, 6, 5, 4, 3, 2, 1, 0, 1, 0, 9, 8 },
        { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7 },
        { 8, 9, 8, 7, 6, 5, 4, 3, 2, 1, 8, 7, 6 },
        { 7, 8, 9, 8, 7, 6, 5, 4, 3, 2, 7, 6, 5 }
        };
        layouts[6].layout = new int[,] {
        { 0, 5, 2, 7, 8, 1, 9, 3, 4, 6, 0, 7, 5 },
        { 3, 8, 1, 6, 9, 4, 0, 2, 7, 5, 3, 6, 4 },
        { 9, 2, 7, 4, 5, 3, 6, 1, 0, 8, 9, 5, 7 },
        { 4, 0, 8, 1, 6, 9, 2, 7, 3, 5, 4, 9, 0 },
        { 2, 9, 3, 7, 5, 8, 0, 4, 6, 1, 2, 7, 3 },
        { 1, 4, 6, 9, 0, 2, 5, 3, 8, 7, 1, 6, 9 },
        { 5, 7, 9, 2, 8, 1, 4, 6, 3, 0, 5, 2, 8 },
        { 6, 1, 5, 9, 7, 4, 3, 0, 8, 2, 6, 1, 4 },
        { 7, 3, 4, 5, 2, 8, 1, 9, 6, 0, 7, 9, 5 },
        { 8, 6, 2, 3, 1, 7, 9, 4, 5, 0, 8, 4, 6 },
        { 3, 5, 9, 4, 6, 2, 7, 8, 0, 1, 3, 9, 7 },
        { 9, 8, 1, 0, 4, 3, 2, 5, 6, 7, 9, 6, 4 }
        };
        layouts[7].layout = new int[,]{ 
        { 0, 0, 2, 2, 2, 3, 3, 3, 7, 7, 7, 4, 4},
        { 0, 0, 2, 2, 2, 8, 3, 8, 7, 7, 7, 4, 4},
        { 2, 2, 3, 3, 8, 8, 8, 8, 8, 3, 3, 7, 7},
        { 2, 2, 3, 3, 8, 8, 8, 8, 8, 3, 3, 7, 7},
        { 2, 2, 8, 8, 8, 8, 9, 8, 8, 8, 8, 7, 7},
        { 8, 8, 8, 8, 8, 9, 6, 9, 8, 8, 8, 8, 8},
        { 8, 8, 8, 8, 8, 9, 6, 9, 8, 8, 8, 8, 8},
        { 5, 5, 8, 8, 8, 8, 9, 8, 8, 8, 8, 1, 1},
        { 5, 5, 3, 3, 8, 8, 8, 8, 8, 3, 3, 1, 1},
        { 5, 5, 3, 3, 8, 8, 8, 8, 8, 3, 3, 1, 1},
        { 4, 4, 5, 5, 5, 8, 3, 8, 1, 1, 1, 0, 0},
        { 4, 4, 5, 5, 5, 3, 3, 3, 1, 1, 1, 0, 0},
         };
         layouts[8].layout = new int[,] {
        { 0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4 },
        { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 4 },
        { 0, 1, 1, 2, 2, 3, 3, 4, 5, 5, 6, 6, 4 },
        { 1, 1, 2, 3, 3, 4, 4, 5, 5, 6, 7, 7, 5 },
        { 1, 2, 3, 4, 5, 5, 6, 6, 7, 7, 8, 8, 6 },
        { 2, 3, 4, 5, 6, 7, 8, 8, 9, 9, 0, 0, 7 },
        { 3, 4, 5, 6, 7, 8, 9, 0, 1, 1, 2, 2, 8 },
        { 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 3, 3, 9 },
        { 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 4, 4, 0 },
        { 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 5, 5, 1 },
        { 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 6, 6, 2 },
        { 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 7, 7, 3 }
        };

        //dificil
        layouts[9].layout = new int[,] {
        { 0, 2, 4, 6, 8, 10, 12, 1, 3, 5, 7, 9, 11 },
        { 1, 3, 5, 7, 9, 11, 0, 2, 4, 6, 8, 10, 12 },
        { 2, 4, 6, 8, 10, 12, 1, 3, 5, 7, 9, 11, 0 },
        { 3, 5, 7, 9, 11, 0, 2, 4, 6, 8, 10, 12, 1 },
        { 4, 6, 8, 10, 12, 1, 3, 5, 7, 9, 11, 0, 2 },
        { 5, 7, 9, 11, 0, 2, 4, 6, 8, 10, 12, 1, 3 },
        { 6, 8, 10, 12, 1, 3, 5, 7, 9, 11, 0, 2, 4 },
        { 7, 9, 11, 0, 2, 4, 6, 8, 10, 12, 1, 3, 5 },
        { 8, 10, 12, 1, 3, 5, 7, 9, 11, 0, 2, 4, 6 },
        { 9, 11, 0, 2, 4, 6, 8, 10, 12, 1, 3, 5, 7 },
        { 10, 12, 1, 3, 5, 7, 9, 11, 0, 2, 4, 6, 8 },
        { 11, 0, 2, 4, 6, 8, 10, 12, 1, 3, 5, 7, 9 }
        };
        layouts[10].layout = new int[,] {
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }
        };
        layouts[11].layout = new int[,] {
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
        { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 0 },
        { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 0, 1 },
        { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 0, 1, 2 },
        { 4, 5, 6, 7, 8, 9, 10, 11, 12, 0, 1, 2, 3 },
        { 5, 6, 7, 8, 9, 10, 11, 12, 0, 1, 2, 3, 4 },
        { 6, 7, 8, 9, 10, 11, 12, 0, 1, 2, 3, 4, 5 },
        { 7, 8, 9, 10, 11, 12, 0, 1, 2, 3, 4, 5, 6 },
        { 8, 9, 10, 11, 12, 0, 1, 2, 3, 4, 5, 6, 7 },
        { 9, 10, 11, 12, 0, 1, 2, 3, 4, 5, 6, 7, 8 },
        { 10, 11, 12, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
        { 11, 12, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
        };
        layouts[12].layout = new int[,] {
        { 0, 3, 7, 11, 9, 5, 8, 1, 4, 12, 6, 2, 10 },
        { 4, 10, 2, 0, 8, 6, 3, 7, 1, 5, 9, 11, 12 },
        { 1, 9, 8, 4, 3, 10, 5, 7, 12, 6, 11, 0, 2 },
        { 3, 5, 10, 9, 2, 12, 4, 8, 6, 1, 7, 11, 0 },
        { 7, 0, 12, 6, 11, 9, 5, 3, 2, 8, 4, 10, 1 },
        { 9, 2, 1, 5, 6, 7, 8, 10, 12, 3, 4, 0, 11 },
        { 5, 0, 3, 11, 9, 1, 10, 4, 6, 12, 8, 7, 2 },
        { 10, 12, 4, 7, 1, 6, 9, 5, 3, 2, 11, 8, 0 },
        { 2, 6, 0, 12, 7, 5, 1, 8, 10, 9, 4, 3, 11 },
        { 12, 11, 4, 8, 10, 3, 2, 9, 7, 5, 1, 6, 0 },
        { 6, 7, 10, 1, 4, 8, 3, 0, 9, 2, 5, 12, 11 },
        { 11, 8, 3, 6, 12, 7, 4, 9, 5, 0, 2, 1, 10 }
        };
    }
    Layout SelectLayout(){
        int max =(dificuldade+1)*4 +1;
        max = max>=numLayouts?numLayouts:max;
        int min = max - 4;
        if (dificuldade==0)
            min--;
        int aleatorio = Random.Range(min, max);
        return layouts[aleatorio];
    }

    void PaintLayout(Layout chao){
        int id=0;
        foreach (int cor in chao.layout ){
            pisos[id].GetComponent<MeshRenderer>().sharedMaterial = listaMateriais[cor];
            id++;
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
        pontos-=dificuldade*(roundMax[dificuldade]-round);
            PointsManager.Perdeu(dificuldade*(roundMax[dificuldade]-round));
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

    int StarterColor(){
        return (dificuldade*4)+round-(dificuldade==0?1:0);

    }

    int RandomColor(int max){
        int aleatorio = Random.Range(0, max);
        return aleatorio;
    }

    int SelectColor(int max){
        if(round <= 5-((dificuldade == 0)?0:1 ))
            return StarterColor();
        else
            return RandomColor(max);
    }

    void NewRound(){
        PaintLayout(SelectLayout());
        Reset();
        round++;
        isRunning =true;
        int max =((dificuldade+1)*4 +1);
        max = max>=13?13:max;
        int aleatorio=SelectColor(max);
        cor = listaCores[aleatorio];
        corTraduzida = Translate(aleatorio); 
        numAparicao[aleatorio]++;
        MessageTimer("TurnOnTimer",10);
        
        textoCor.text = corTraduzida;
        if(numAparicao[aleatorio]<=1 && (aleatorio>dificuldade*4 || dificuldade==0)){
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
