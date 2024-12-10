using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC;
using Unity.VisualScripting;

public class AnimatorAnimation : MonoBehaviour
{
    public UnityEngine.Object[] proximo;
    private Animator[] proximoAnimator;
    private int id=0;
    public float TriggerDistance =7f;
    // Start is called before the first frame update
    void Start()
    {
        proximoAnimator = new Animator[proximo.Length];
        if(proximo.Length>0){
            for(int i=0;i<proximo.Length; i++){
                proximoAnimator[i] = proximo[i].GetComponent<Animator>();
            }
                
            
        }
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        if(DistanceFromCamera() <= TriggerDistance){
            GetComponent<Animator>().SetTrigger("selectedTrigger");
        }
            
    }

    void OnTriggerEnter(){
        GetComponent<Animator>().SetTrigger("collisionTrigger");
    }

    void PlaySoundBegin(UnityEngine.Object clip){
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip=(AudioClip)clip;
        AnimatorStateInfo state = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        float speed = state.speed * state.speedMultiplier;
        if(speed >0){
            GetComponent<Sound>().Play();
        }
        
    }

    void PlaySoundEnd(UnityEngine.Object clip){
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip=(AudioClip)clip;
        AnimatorStateInfo state = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        float speed = state.speed * state.speedMultiplier;
        if(speed <0){
            GetComponent<Sound>().Play();
        }
        
    }

    void PlaySoundReverse(UnityEngine.Object clip){
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip=(AudioClip)clip;
        AnimatorStateInfo state = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        audioSource.pitch = state.speed * state.speedMultiplier;
        if(audioSource.pitch <0){
            audioSource.time = audioSource.clip.length - 0.01f;
        }
        GetComponent<Sound>().Play();
    }

    void StopSound(UnityEngine.Object clip){
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip=(AudioClip)clip;
        audioSource.Stop();
    }

    void TriggerNext(){

        proximoAnimator[id++].SetTrigger("nextTrigger");
        id%=proximo.Length;

    }

    void Die(){
        GameObject.Destroy(gameObject);
    }

    float DistanceFromCamera(){
        Vector3 heading = transform.position - Camera.main.transform.position;
        float distance = Vector3.Dot(heading,Camera.main.transform.forward);
        return distance;
    }
}
