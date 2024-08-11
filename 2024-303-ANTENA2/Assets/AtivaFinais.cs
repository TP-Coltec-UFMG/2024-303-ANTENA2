using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaFinais : MonoBehaviour {

    [SerializeField] private GameObject primeiroFinal;
    [SerializeField] private GameObject segundoFinal;

    void Start() {
        
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Keypad1)) {
            primeiroFinal.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Keypad2)) {
            segundoFinal.SetActive(true);
        }
    }
}
