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
    [SerializeField] private Animator FadeOutTrab;
    [SerializeField] private Animator FadeDia;
    private int dia = 0;
    
    private void Start() {
        dia = GameHandler.Dia;
        if(dia > 0) {
            FadeOutTrab.Play("FadeOutTrab"); //fade out do fim trabaio
        }
    }

    private void Update()
    {
        if (FadeDia.GetCurrentAnimatorStateInfo(0).IsName("FadeInDia") && !(FadeDia.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1f)){
            SceneManager.LoadScene(cena);
        }
    }
    
    void OnTriggerEnter2D (Collider2D collider) {
        GameHandler.Dia ++;
        textoDiaTrans.text = GameHandler.Dia.ToString();

        FadeDia.Play("FadeInDia"); //fade in dia x
    }
}