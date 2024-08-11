using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PassaDia : MonoBehaviour {
    public int idCena = 2;
    public string cena = "Mesa";
    [SerializeField] private TMP_Text textoDiaTrans;
    //textoDiaTrans.text = dia.ToString();

    private void Start(){
        //fade out do fim trabaio?
    }

    void Update(){}
    void OnTriggerEnter2D (Collider2D collider) {
        //meter fadeIn do dia
        SceneManager.LoadScene(cena);
        GameHandler.Dia ++;
    }
}