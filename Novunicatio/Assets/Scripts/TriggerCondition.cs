using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;
using Unity.VisualScripting;

public class TriggerCondition : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if((int)PointsManager.fase >= (int) PointsManager.cores.Minimo){
            GetComponent<AnimatorAnimation>().flagNext = true;
        }
        else{
            GetComponent<AnimatorAnimation>().flagNext = false;
        }
    }
}
