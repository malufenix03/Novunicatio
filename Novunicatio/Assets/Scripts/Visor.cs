using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visor : MonoBehaviour
{
    void Start(){
//        GameObject controlCenter = GameObject.Find("ControlCenter");
        print(PointsManager.fase);
        print(PointsManager.points);
        int estado = (int) PointsManager.fase;
        if(estado != 0){
            for(int i=1;i<=4;i++)
                if(estado >= i)
                    transform.GetChild(i).gameObject.SetActive(true);
                else
                        break;
        }
            
    }

}
