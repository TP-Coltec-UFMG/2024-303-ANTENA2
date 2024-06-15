using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dalton : MonoBehaviour
{
    public int filtroAtual;
    public void protanopia() {
        Colorblind.Type = 1;
        filtroAtual = 1;
        //botao.Select();
    }
    
    public void tritanopia() {
        Colorblind.Type = 3;
        filtroAtual = 3;
    }
    
    public void deuteranopia() {
        Colorblind.Type = 2;
        filtroAtual = 2;
    }
    
    public void semFiltro() {
        Colorblind.Type = 0;
        filtroAtual = 0;
    }
}
