using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    static public int points = 0;
    public enum cores{Incompleto,Facil,Minimo,Dificil,Extremo}
    
    static public bool perdeu = false;

    static public cores fase = 0;
    
    void Awake()
    {
        
            
    }

    
    static public void Ganhou(int gamePoint){
        points+=gamePoint;
    }
    static public void Perdeu(int gamePoint){
        print("PERDEU");
        print(gamePoint);
        print(points);
        points-=gamePoint;
        print(points);
    }

}
