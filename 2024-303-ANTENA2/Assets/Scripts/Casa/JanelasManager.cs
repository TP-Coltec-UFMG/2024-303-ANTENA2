using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JanelasManager : MonoBehaviour {
    [SerializeField] private GameObject texto;
    [SerializeField] private TMP_Text qtd_janelas;
    [SerializeField] private GameObject janelaTransSprite;
    [SerializeField] private GameObject janelaArmazemSprite;
    [SerializeField] private Janelas janelaTrans;
    [SerializeField] private Janelas janelaArmazem;
    public static int janelasFechadas;
    void Start(){
        if(GameHandler.Dia != 0){
            janelasFechadas = 0;
            janelaTransSprite.SetActive(false);
            janelaArmazemSprite.SetActive(false);
        }
    }
    void Update(){
        if(GameHandler.Dia != 0){
            qtd_janelas.text = string.Format("Janelas fechadas: {00}/6", janelasFechadas);
        } else if(GameHandler.Dia == 0){
            texto.SetActive(false);
        }
        if(janelaTrans.foiFechada == true){
            janelaTransSprite.SetActive(true);
        }
        if(janelaArmazem.foiFechada == true){
            janelaArmazemSprite.SetActive(true);
        }
    }
}
