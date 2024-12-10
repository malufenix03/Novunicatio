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
    public bool primeiro = true;
    public bool segundo = false;


    public void PlacePlayer(){
        playerObject = GameObject.Find("Player").gameObject;
        player = playerObject.GetComponent<Player>();
     //   KickStarter.player.Teleport(posicao());
        player.transform.position = posicao();
        print(player.transform.position);
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
    void EnableMovement(){
        player.upMovementLocked = false;
		player.downMovementLocked = false;
		player.leftMovementLocked = false;
		player.rightMovementLocked = false;
        player.jumpingLocked = false;
    }
}
