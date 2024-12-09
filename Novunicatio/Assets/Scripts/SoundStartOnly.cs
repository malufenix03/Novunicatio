using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;


public class SoundStartOnly: MonoBehaviour{
    public int anterior;

    void Start(){

        if(KickStarter.sceneChanger.PreviousSceneIndex == -1){
            GetComponent<Sound>().Play();
        }
    }
}
