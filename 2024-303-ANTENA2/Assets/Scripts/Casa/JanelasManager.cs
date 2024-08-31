using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JanelasManager : MonoBehaviour {
    [SerializeField] private GameObject texto;
    [SerializeField] private TMP_Text qtd_janelas;
    public static int janelasFechadas;
    void Update(){
        if(GameHandler.Dia != 0){
            qtd_janelas.text = string.Format("Janelas fechadas: {00}/6", janelasFechadas);
        } else if(GameHandler.Dia == 0){
            texto.SetActive(false);
        }
    }
}
