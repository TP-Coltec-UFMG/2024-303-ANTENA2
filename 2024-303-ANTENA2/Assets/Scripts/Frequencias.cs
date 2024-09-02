using System;
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
    [SerializeField] private Button aumentaFrequencia;
    [SerializeField] private Button diminuiFrequencia;
    public float frequencia;

    public static Frequencias Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        aumentaFrequencia.onClick.AddListener(() =>
        {
            frequencia += .1f;
            slider.value += 1f;
        });
        diminuiFrequencia.onClick.AddListener(() =>
        {
            frequencia -= .1f;
            slider.value -= 1f;
        });
    }
    
    void Update()
    {
        frequencia = slider.value / 10;
        
        textoFrequencia.text = Mathf.FloorToInt(frequencia).ToString("D3");
        textoFrequencia2.text = Mathf.RoundToInt(frequencia % 1 * 10).ToString();
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
