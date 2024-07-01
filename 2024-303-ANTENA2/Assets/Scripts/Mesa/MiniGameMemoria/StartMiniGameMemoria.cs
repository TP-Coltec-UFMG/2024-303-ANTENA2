using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMiniGameMemoria : MonoBehaviour {
    [SerializeField] private GameManagerMemoria GM;
    void Awake() {
        GM = FindObjectOfType<GameManagerMemoria>();  
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.M)) {
            GM.StartGame();   
        }
    }
}
