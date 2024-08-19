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
    private float frequencia;

    private void Start()
    {
        aumentaFrequencia.onClick.AddListener(() =>
        {
            frequencia += .1f;
            slider.value += .1f;
        });
        diminuiFrequencia.onClick.AddListener(() =>
        {
            frequencia -= .1f;
            slider.value -= .1f;
        });
    }
    
    void Update()
    {
        frequencia = slider.value + 100.0f;
        
        // int aux = (int)(frequencia * 10);
        int remainder = Mathf.RoundToInt(frequencia % 1 * 10);
        int aux = Mathf.FloorToInt(frequencia);
        string aux2 = aux.ToString();
        // string aux3 = aux2[3].ToString();
        string aux3 = remainder.ToString();
        // aux2 = aux2.Remove(3);
    
        Debug.Log($"frequencia {frequencia}");
        Debug.Log($"remainder {remainder}");
        Debug.Log($"aux {aux}");
        Debug.Log($"aux2 {aux2}");
        Debug.Log($"aux3 {aux3}");
        
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
