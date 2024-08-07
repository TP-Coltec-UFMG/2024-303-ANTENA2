using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PassaDia : MonoBehaviour {
    public int idCena = 2;
    public string cena = "Mesa";

    void Update(){}
    void OnTriggerEnter2D (Collider2D collider) {
        SceneManager.LoadScene(cena);
        GameHandler.Dia ++;
    }
}