using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JanelasManager : MonoBehaviour {
    [SerializeField] private GameObject texto;
    [SerializeField] private TMP_Text qtd_janelas;
    [SerializeField] private GameObject janelaTrans;
    [SerializeField] private GameObject janelaArmazem;
    public static int janelasFechadas;
    void Start(){
        if(GameHandler.Dia != 0){
            janelasFechadas = 0;
            //janelaTrans aberta
            //janelaArmazem aberta
        }
    }
    void Update(){
        if(GameHandler.Dia != 0){
            qtd_janelas.text = string.Format("Janelas fechadas: {00}/6", janelasFechadas);
        } else if(GameHandler.Dia == 0){
            texto.SetActive(false);
        }
        //if janelaTrans foiFechada == true -> bota a imagem da janela fechada
        //if janelaArmazem foiFechada == true -> bota a imagem da janela fechada
        
    }
}
