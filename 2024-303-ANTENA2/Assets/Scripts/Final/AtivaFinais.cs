using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaFinais : MonoBehaviour {

    [SerializeField] private GameObject primeiroFinal;
    [SerializeField] private GameObject segundoFinal;

    public static int QualFinal = -1;

    private void Start()
    {
        switch (QualFinal)
        {
            case 1:
                primeiroFinal.SetActive(true);
                break;
            case 2:
                segundoFinal.SetActive(true);
                break;
        }
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1)) {
            primeiroFinal.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2)) {
            segundoFinal.SetActive(true);
        }
    }
}
