using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Janelas : MonoBehaviour {
    //[SerializeField] private GameObject player;
    //[SerializeField] private Collider2D janelas;
    [SerializeField] private GameObject textoFechar;
    public bool foiFechada = false;
    public bool stay = false; //fazendo a função do OnCollisionStays
    void Update(){
        if(stay == true){
            if(Input.GetKeyDown(KeyCode.F)){
                Debug.Log("pertou");
                JanelasManager.janelasFechadas++;
                foiFechada = true;
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