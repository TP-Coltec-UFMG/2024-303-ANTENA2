using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class ControllerQuartoDia : MonoBehaviour {
    [SerializeField] private SistemaLegendasQuartoDia legendas;
    [SerializeField] private GameObject Skip;
    [SerializeField] private GameObject Next;
    void Awake() {
        legendas = FindObjectOfType<SistemaLegendasQuartoDia>();
       
        legendas.Next();

        Skip.SetActive(true);
        Debug.Log("Skip active");

        Next.SetActive(true);
        Debug.Log("Next active");  
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.Return)) {
            legendas.Next();   
        }
    }
}
