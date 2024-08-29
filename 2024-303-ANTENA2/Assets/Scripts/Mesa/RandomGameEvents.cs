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
    void RandomizeGames() {
        randomNumber = Random.Range(0, max_number);
        if(randomNumber == 1) {
            gameManagerMemoria.StartGame();
        }
        if(randomNumber == 2) {
            miniGameFios.StartFios();
        }
    }
}
