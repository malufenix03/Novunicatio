using System.Collections;
using System.Collections.Generic;
using DoorScript;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class DoorOpen : MonoBehaviour
{
    public Vector3 closedDoorCenter;
    public Vector3 closedDoorPosition;
    public Vector3 openDoorCenter;
    public Vector3 openDoorPosition;

    // Quando clica
    void OnMouseDown(){
        Door door = GetComponent<Door>();
        BoxCollider collider = GetComponent<BoxCollider>();
        door.OpenDoor();
    }
}
