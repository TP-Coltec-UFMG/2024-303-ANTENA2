using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Janelas : MonoBehaviour {
    [SerializeField] private GameObject textoFechar;
    [SerializeField] public AudioSource janelaFechando;
    static public bool foiFechada = false;
    public int numApertancias = 0;
    public bool stay = false; //fazendo a função do OnCollisionStay
    void Update(){
        if(stay == true && numApertancias == 0){
            if(Input.GetKeyDown(KeyCode.F)){
                JanelasManager.janelasFechadas++;
                foiFechada = true;
                numApertancias++;
                janelaFechando.Play();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(foiFechada == false){
            textoFechar.SetActive(true);
            stay = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if(textoFechar != null){
            textoFechar.SetActive(false);
        }
        stay = false;
    }
}
