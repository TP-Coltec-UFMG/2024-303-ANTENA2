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

    [SerializeField] private GameObject fadeInDia;
    [SerializeField] private Animator fadeIntrabaioa;
    //textoDiaTrans.text = dia.ToString();

    private bool _isAnimationPlaying = false;
    
    private void Start() {
        //fade out do fim trabaio?
        fadeIntrabaioa.Play("wdiopawjdoian");
    }

    private void Update()
    {
        if (_isAnimationPlaying)
        {
            fadeInDia.GetComponent<Animator>();//.IsEnded();
            SceneManager.LoadScene(cena);
            GameHandler.Dia ++;
        }
    }
    
    void OnTriggerEnter2D (Collider2D collider) {
        //meter fadeIn do dia
        fadeInDia.GetComponent<Animator>().Play("WUDHBAWUIODB");
        _isAnimationPlaying = true;
        // SceneManager.LoadScene(cena);
        // GameHandler.Dia ++;
    }
}