using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public int points = 0;
    public enum cores{Incompleto,Facil,Minimo,Dificil,Extremo}
    
    public cores fase = 0;
    
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    
    void Ganhou(int gamePoint){
        points+=gamePoint;
    }
    void Perdeu(int gamePoint){
        points-=gamePoint;
    }

}
