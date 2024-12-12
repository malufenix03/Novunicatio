using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;
using Unity.VisualScripting;

public class EndGame : MonoBehaviour
{
    public GameObject saida;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = saida.GetComponent<Animator>();
    }
    void Update(){
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("subir portao cor")){
            Menu menu;
            if(PointsManager.points>=60)
                 menu = PlayerMenus.GetMenuWithName ("FimDeJogo");
            else
                 menu = PlayerMenus.GetMenuWithName ("FimDeJogo60");
            menu.TurnOn ();
            
        }

    }
}
