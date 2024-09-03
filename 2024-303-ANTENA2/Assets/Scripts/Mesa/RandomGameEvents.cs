using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGameEvents : MonoBehaviour {
    
    [SerializeField] private int randomNumber;
    [SerializeField] int max_number;
    [SerializeField] float time;

    /*Mini Game Memoria*/
    [SerializeField] GameObject telinha;
    private GameManagerMemoria gameManagerMemoria;

    /*Mini Game Fios*/
    [SerializeField] GameObject mesa;
    private MiniGames miniGameFios;

    [SerializeField] PaneNaMesa paneNaMesa;

    /*Guitar Hero*/

    void Awake() {
        gameManagerMemoria = telinha.GetComponent<GameManagerMemoria>();
        miniGameFios = mesa.GetComponent<MiniGames>();
    }
    void Start() {
        if (GameHandler.Dia != 1){
            if(gameManagerMemoria.gameOn == false && miniGameFios.fiosOn == false) {
                InvokeRepeating("RandomizeGames", 0f, time);
            }
        }
    }
    void Update(){
        if (Dificuldade.dificuldade == "facil") {
            time = 90f;
            max_number = 35;
        } else if(Dificuldade.dificuldade == "medio") {
            time = 50f;
            max_number = 20;
        } else {
            time = 20f;
            max_number = 10;
        }
    }
    void RandomizeGames() {
        randomNumber = Random.Range(0, max_number);
        if(randomNumber == 1) {
            paneNaMesa.desligaMesa();
            gameManagerMemoria.StartGame();
        }
        if(randomNumber == 2) {
            paneNaMesa.desligaMesa();
            miniGameFios.StartFios();
        }
    }
}
