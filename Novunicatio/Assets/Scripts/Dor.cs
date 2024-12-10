using System.Collections;
using System.Collections.Generic;
using AC;
using UnityEngine;

public class Dor : MonoBehaviour
{
    public Vector3 anterior= new Vector3(-1,-1,-1);
    public Vector3 atual;

    // Start is called before the first frame update
    void Update()
    {
        atual= transform.position;
        if(anterior!=atual){
          //  print("OLha "+atual);
        }
        anterior=atual;
    }

  void Doi(){
      print(SceneChanger.CurrentSceneIndex);
      print("HJEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
      print(KickStarter.sceneChanger.GetPreviousSceneIndex());
  }
    // Update is called once per frame

  void OnCharacterTeleport (AC.Char character, Vector3 position, Quaternion rotation){
      print("teleportou aqui: "+position);
  }
  void OnEnable(){
    EventManager.OnCharacterTeleport += OnCharacterTeleport;
    EventManager.OnPlayerSpawn += OnPlayerSpawn;
    EventManager.OnSetPlayer += OnSetPlayer;
  }
  void OnDisable(){
    EventManager.OnCharacterTeleport -= OnCharacterTeleport;
    EventManager.OnPlayerSpawn -= OnPlayerSpawn;
    EventManager.OnSetPlayer -= OnSetPlayer;
  }

  void OnPlayerSpawn (AC.Char character){
      print("spawnou aqui: "+character.transform.position);
  }

  void OnSetPlayer (AC.Char character){
      print("setou aqui: "+character.transform.position);
  }


}
