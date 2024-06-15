using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Frequencias : MonoBehaviour
{
    [SerializeField] public Slider slider;
    [SerializeField] public TextMeshProUGUI textoFrequencia;
    private float frequencia;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(textoFrequencia.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        frequencia = slider.value + 100.0f;
        int aux = (int)(frequencia * 10);
        string aux2 = aux.ToString();
        //aux2.Insert(3, "        ");

        Debug.Log(aux);
        Debug.Log(frequencia);
        textoFrequencia.text = aux2;
    }

    public bool checaFrequencia(float frequenciaExterna)
    {
        bool checaIgualdade;

        if(frequenciaExterna == frequencia)
        {
            checaIgualdade = true;
        }
        else
        {
            checaIgualdade = false;
        }

        return checaIgualdade;
    }
}
