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
    [SerializeField] public TextMeshProUGUI textoFrequencia2;
    private float frequencia;

    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frequencia = slider.value + 100.0f;

        int aux = (int)(frequencia * 10);
        string aux2 = aux.ToString();
        string aux3 = aux2[3].ToString();
        aux2 = aux2.Remove(3);

        textoFrequencia.text = aux2;
        textoFrequencia2.text = aux3;
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
