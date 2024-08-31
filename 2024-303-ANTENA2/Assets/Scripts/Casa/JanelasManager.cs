using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JanelasManager : MonoBehaviour {
    [SerializeField] private TMP_Text qtd_janelas;
    public static int janelasFechadas;
    void Update(){
        qtd_janelas.text = string.Format("Janelas fechadas: {00}/6", janelasFechadas);
    }
}
