using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TextMeshPro texto;
    public int duration = 30;
    private float time;
    private int timeRemaining;
    private bool isCounting = false;

    // Start is called before the first frame update
    void Start()
    {
        texto = transform.GetChild(0).GameObject().GetComponent<TextMeshPro>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isCounting)
            time = time - Time.deltaTime;
            Seconds();
    }

    public void TurnOnTimer(int tempo){
        time = (float)duration;
        timeRemaining = duration;
        duration=tempo;
        isCounting=true;
        RestartTimer();
    }
    public void TurnOffTimer(){
        isCounting=false;
    }
    public void RestartTimer(){
        timeRemaining=duration;
        time=duration;
        Seconds();
    }
    public void Seconds(){
        timeRemaining = ((int)time)%60;
        texto.text = "0:" + timeRemaining.ToString("00");
    }
}
