using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextoOperadorSO : MonoBehaviour
{
    public int dia = GameHandler.Dia;
    public List<EscritosSO> escritos;
    public TextMeshPro texto;
    public string textoOnCollision;

    private int lastPosition = 0;

    private void Start()
    {
        lastPosition = 0;
    }

    public int defineTexto(int lastPos)
    {
        EscritosSO escritoAux;
        int i;

        for(i = (lastPos + 1); i < escritos.Count; i++)
        {
            escritoAux = escritos[i];
            if(escritoAux.Dia == dia)
            {
                texto.text = escritoAux.escrito;
                lastPos = i;
            }
        }

        return lastPos;
    }

    public void OnCollisionEnter2D()
    {
        lastPosition = defineTexto(lastPosition);
    }
}