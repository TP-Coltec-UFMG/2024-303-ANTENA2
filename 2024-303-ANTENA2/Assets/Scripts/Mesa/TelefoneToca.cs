using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TelefoneToca : MonoBehaviour {
    public AudioSource toque;
    public AudioSource gancho;
    void Start(){
        if(GameHandler.Dia == 1){
            toque.Play();
        }
    }
    public void OnMouseDown(){
        toque.Stop();
        gancho.Play();
    }
}