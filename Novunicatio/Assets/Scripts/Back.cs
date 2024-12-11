using System.Collections;
using System.Collections.Generic;

using AC;
using Unity.VisualScripting;
using UnityEngine;

public class Back : MonoBehaviour
{
    public bool perdeu;
    public Vector3 derrota;
    public Vector3 vitoria;
    private GameObject playerObject;
    private Player player;

    void Awake(){
        playerObject = GameObject.Find("Player").gameObject;
        player = playerObject.GetComponent<Player>();
    }

    void Update(){
        if(player.transform.position.y < 0.009)
            player.transform.position = new Vector3 (player.transform.position.x,0.1f,player.transform.position.z);
    }

    public void PlacePlayer(){
        
     //   KickStarter.player.Teleport(posicao());
        player.transform.position = posicao();
        player.transform.eulerAngles = sentido();
        EnableMovement();
    //    KickStarter.player.Teleport(posicao());
    }

    Vector3 posicao(){
       perdeu = PointsManager.perdeu;
       if(perdeu){
            return derrota;
       }
       else{
            return vitoria;
       }
    }
    Vector3 sentido(){
       if(perdeu){
            return new Vector3(0f,0f,0f);
       }
       else{
            return new Vector3(0f,0f,180f);
       }
    }
    void EnableMovement(){
        player.upMovementLocked = false;
		player.downMovementLocked = false;
		player.leftMovementLocked = false;
		player.rightMovementLocked = false;
        player.jumpingLocked = false;
    }
}
