using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHookable : MonoBehaviour
{
    void OnPlatformMove(Vector3 by){
        transform.Translate(by);
    }
}