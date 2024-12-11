using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveGame : MonoBehaviour
{
    public float TriggerDistance =7f;
    public bool perdeu = false;
    void OnMouseDown()
    {
        if(DistanceFromCamera() <= TriggerDistance){
            PointsManager.perdeu=perdeu;
        }
            
    }
    float DistanceFromCamera(){
        Vector3 heading = transform.position - Camera.main.transform.position;
        float distance = Vector3.Dot(heading,Camera.main.transform.forward);
        return distance;
    }
}
