using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMiniGameMemoria : MonoBehaviour {

    private GameObject telinha_minigame;
    private GameManagerMemoria GM;
    [SerializeField] private GameObject mesaVerdinha;
    void Awake() {
        //GM = FindObjectOfType<GameManagerMemoria>();  
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.M)) {
            mesaVerdinha.SetActive(true);
            if(mesaVerdinha.activeInHierarchy == true) {
                telinha_minigame = GameObject.Find("BotoesTelinha_MiniGame");
                GM = telinha_minigame.GetComponent<GameManagerMemoria>(); 
                GM.StartGame();   
            }
            
        }
    }
}
