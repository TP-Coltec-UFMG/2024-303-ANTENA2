using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerCenasDia4 : MonoBehaviour {

    [SerializeField] private GameObject cena1; // Final
    [SerializeField] private GameObject cena2;
    [SerializeField] private GameObject cena3;
    [SerializeField] private GameObject cena4;
    [SerializeField] private GameObject cena5;
    [SerializeField] private GameObject cena6;
    [SerializeField] private Scene cenaCasa;
    [SerializeField] private botaoDoCoisoQueDecide botaoQueFoi;

    public static int QualFinal = 0;

    private void Start()
    {
        cena1.SetActive(true);
    }

    void Update() {
        if (cena1.activeSelf == true && cena1.GetComponent<SistemaLegendasFinal>().finalizado == true)
        {
            cena1.SetActive(false);
            
            
            if (botaoQueFoi.botaoPressed == 0)
            {
                cena2.SetActive(true);
            }
            else if(botaoQueFoi.botaoPressed == 1)
            {
                cena6.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene(cenaCasa.name);
            }
        }
        else if (cena2.activeSelf == true && cena2.GetComponent<SistemaLegendasFinal>().finalizado == true)
        {
            cena2.SetActive(false);
            cena3.SetActive(true);
        }
        else if (cena3.activeSelf == true && cena3.GetComponent<SistemaLegendasFinal>().finalizado == true)
        {
            cena3.SetActive(false);
            cena4.SetActive(true);
        }
        else if (cena4.activeSelf == true && cena4.GetComponent<SistemaLegendasFinal>().finalizado == true)
        {
            cena4.SetActive(false);
            cena5.SetActive(true);
        }
        else if (cena5.activeSelf == true && cena5.GetComponent<SistemaLegendasFinal>().finalizado == true)
        {
            cena5.SetActive(false);
            SceneManager.LoadScene(cenaCasa.name);
        }
        else if (cena6.activeSelf == true && cena6.GetComponent<SistemaLegendasFinal>().finalizado == true)
        {
            cena6.SetActive(false);
            SceneManager.LoadScene(cenaCasa.name);
        }
    }
}
