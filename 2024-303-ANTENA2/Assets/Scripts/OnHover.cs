using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OnHover : MonoBehaviour
{
    public Botao botoes;
    public int filtroAtual;

    public void OnMouseEnter() {
        filtroAtual = Colorblind.Type;

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

    public enum Botao{
        Deuteranopia,
        Protanopia,
        Tritanopia,
        SemFiltro
    }
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
