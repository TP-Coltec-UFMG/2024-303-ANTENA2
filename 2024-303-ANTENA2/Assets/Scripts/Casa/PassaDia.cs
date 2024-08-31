using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PassaDia : MonoBehaviour {
    public string cena = "Mesa";
    [SerializeField] private TMP_Text textoDiaTrans;
    [SerializeField] private Animator FadeOutTrab;
    [SerializeField] private Animator FadeDia;
    [SerializeField] private GameObject botao;
    [SerializeField] private AudioSource musiquinhaDia1;
    [SerializeField] private AudioSource musiquinhaCasa;
    [SerializeField] private GameObject tutoAndar;
    
    public int dia;
    
    private void Start() {
        dia = GameHandler.Dia;
        if(dia != 0) {
            FadeOutTrab.Play("FadeOutTrab"); //fade out do fim trabaio
            musiquinhaCasa.Play();

        }
        if(dia == 0){
            musiquinhaDia1.Play(); //musiquinha com chuvinha

            //"ande com awsd ou setinhas"
            tutoAndar.SetActive(true);
            //depois de 7 segundos some 
            Destroy(tutoAndar, 7);
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
        botao.SetActive(false);

        FadeDia.Play("FadeInDia"); //fade in dia x
    }
}