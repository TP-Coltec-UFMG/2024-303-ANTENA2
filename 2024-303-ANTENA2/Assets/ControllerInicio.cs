using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class ControllerInicio : MonoBehaviour {
    [SerializeField] private SistemaLegendas legendas;
    [SerializeField] private GameObject Skip;
    [SerializeField] private GameObject Next;
    void Awake() {
        legendas = FindObjectOfType<SistemaLegendas>();
       
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
