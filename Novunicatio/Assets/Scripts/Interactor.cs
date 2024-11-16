using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private GameManager m_Manager;
    public float m_TriggerDistance = 7f;
    void Start()
    {
        GameObject controlCenter = GameObject.Find("ControlCenter");
        if(controlCenter==null)
            Debug.LogError("Cadê o ControlCenter");
        else{
            m_Manager = controlCenter.GetComponent<GameManager>();
        }
    }
    void OnMouseEnter(){
        print(DistanceFromCamera());
        if(DistanceFromCamera() <= m_TriggerDistance){
            m_Manager.CursorColorChange(true);
        }
            
    }
    void OnMouseExit(){
        m_Manager.CursorColorChange(false);
    }

    float DistanceFromCamera(){
        Vector3 heading = transform.position - Camera.main.transform.position;
        float distance = Vector3.Dot(heading,Camera.main.transform.forward);
        return distance;
    }

}
