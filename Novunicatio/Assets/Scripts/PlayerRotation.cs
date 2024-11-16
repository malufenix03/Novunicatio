using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;

public class PlayerRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float RotationSpeed=20.0f;
    public Transform PlayerBody;    //referencia ao corpo do player
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //obter inputs do Adventure Creator
        float turn = KickStarter.playerInput.InputGetAxis("Turn");
        //obter os ângulos atuais do transform em Euler
        Vector3 currentRotation = PlayerBody.eulerAngles;
        //atualizar angulo de rotacao no eixo y (giro horizontal)
        currentRotation.y += turn *RotationSpeed * Time.deltaTime;
        PlayerBody.eulerAngles = currentRotation;
    }
}
