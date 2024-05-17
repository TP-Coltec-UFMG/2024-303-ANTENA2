using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dalton : MonoBehaviour
{
    public int filtroAtual = Colorblind.Type;
    public void protanopia() {
        Colorblind.Type = 1;
        filtroAtual = 1;
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
    /*public Botao botoes;

    public void OnMouseEnter() {

        switch(botoes) {
            case Botao.Deuteranopia:
                Colorblind.Type = 2;
                break;
            case Botao.Protanopia:
                Colorblind.Type = 1;
                break;
            case Botao.Tritanopia:
                Colorblind.Type = 3;
                break;
            case Botao.SemFiltro:
                Colorblind.Type = 0;
                break;

            default:
                break;
        }
    }
    public void OnMouseExit() {
        Colorblind.Type = filtroAtual;
    }

    public void Teste(){
        switch(botoes) {
            case Botao.Deuteranopia:
                Colorblind.Type = 2;
                filtroAtual = 2;
                break;
            case Botao.Protanopia:
                Colorblind.Type = 1;
                filtroAtual = 1;
                break;
            case Botao.Tritanopia:
                Colorblind.Type = 3;
                filtroAtual = 3;
                break;
            case Botao.SemFiltro:
                Colorblind.Type = 0;
                filtroAtual = 0;
                break;

            default:
                break;
        }
    }

    public enum Botao{
        Deuteranopia,
        Protanopia,
        Tritanopia,
        SemFiltro
    }*/
}
