using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frequencias : MonoBehaviour
{
    [SerializeField] public Slider slider;
    private float frequencia;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frequencia = slider.value + 100;
        Debug.Log(frequencia);
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
