using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerCenasDia4 : MonoBehaviour {

    [SerializeField] private GameObject cena1; // Final
    [SerializeField] private GameObject cena2;
    [SerializeField] private GameObject cena3;
    [SerializeField] private GameObject cena4;
    [SerializeField] private GameObject cena5;
    [SerializeField] private GameObject cena6;
    [SerializeField] private Scene cenaCasa;
    [SerializeField] private botaoDoCoisoQueDecide botaoQueFoi;
    [SerializeField] private GameObject SkipAntesPorta;
    [SerializeField] private GameObject NextAntesPorta;
    [SerializeField] private GameObject Sim;
    [SerializeField] private GameObject Nao;
    [SerializeField] private TextMeshProUGUI textAbrirPorta;

    public static int QualFinal = 0;

    private void Start()
    {
        Sim.SetActive(false);
        Nao.SetActive(false);
        cena1.SetActive(true);
    }

    void Update() {
        if (cena1.activeSelf == true && cena1.GetComponent<SistemaLegendasQuartoDia>().finalizado == true) {
            SkipAntesPorta.SetActive(false);
            NextAntesPorta.SetActive(false);
            textAbrirPorta.text = "Abrir a porta?";
            Sim.SetActive(true);
            Nao.SetActive(true);
        }
        else if (cena2.activeSelf == true && cena2.GetComponent<SistemaLegendasQuartoDia>().finalizado == true)
        {
            cena2.SetActive(false);
            cena3.SetActive(true);
        }
        else if (cena3.activeSelf == true && cena3.GetComponent<SistemaLegendasQuartoDia>().finalizado == true)
        {
            cena3.SetActive(false);
            cena4.SetActive(true);
        }
        else if (cena4.activeSelf == true && cena4.GetComponent<SistemaLegendasQuartoDia>().finalizado == true)
        {
            cena4.SetActive(false);
            cena5.SetActive(true);
        }
        else if (cena5.activeSelf == true && cena5.GetComponent<SistemaLegendasQuartoDia>().finalizado == true)
        {
            cena5.SetActive(false);
            SceneManager.LoadScene("Casa");
        }
        else if (cena6.activeSelf == true && cena6.GetComponent<SistemaLegendasQuartoDia>().finalizado == true)
        {
            cena6.SetActive(false);
            SceneManager.LoadScene("Casa");
        }
    }

    public void botaoSim() {
        cena1.SetActive(false);
        Sim.SetActive(false);
        Nao.SetActive(false);
        cena2.SetActive(true);
    }

    public void botaoNao() {
        cena1.SetActive(false);
        Sim.SetActive(false);
        Nao.SetActive(false);
        cena6.SetActive(true);
    }
}
