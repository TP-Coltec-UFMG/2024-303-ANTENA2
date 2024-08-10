using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private string diaDoJogo;
    [SerializeField] private GameObject painelInicial;
    [SerializeField] private GameObject painelConfig;
    [SerializeField] private GameObject painelCreditos;
    public void Jogar(){
        SceneManager.LoadScene("Inicio");
        Debug.Log("Abrir Jogo");
    }

    public void Configurar(){
        painelInicial.SetActive(false);
        painelConfig.SetActive(true); 
    }

    public void FecharConfig(){
        painelConfig.SetActive(false);
        painelInicial.SetActive(true);
    }

    public void Creditos(){
        painelInicial.SetActive(false);
        painelCreditos.SetActive(true);
    }

    public void FecharCreditos()
    {
        painelCreditos.SetActive(false);
        painelInicial.SetActive(true);
    }
    public void Sair(){
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
