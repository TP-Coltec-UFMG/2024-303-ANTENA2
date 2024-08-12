using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class TextoOperadorSO : MonoBehaviour
{
    public int dia = GameHandler.Dia;
    public List<EscritosSO> escritos;
    public TextMeshPro texto;
    public string textoOnCollision;

    public void defineTexto()
    {
        texto.text = escritos[dia].escrito;
    }

    public void OnCollisionEnter2D()
    {
        defineTexto();
    }
}