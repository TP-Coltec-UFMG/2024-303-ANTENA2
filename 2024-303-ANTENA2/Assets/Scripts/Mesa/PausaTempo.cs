using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaTempo : MonoBehaviour {
    [SerializeField] GameObject tutorial;
    [SerializeField] GameObject configs;
    // Update is called once per frame
    void Update()
    {
        if(configs.activeSelf == true /*|| tutorial.activeSelf == true*/){
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
        
    }
    /*void PausarJogo() {
        if (Time.timeScale == 0) {
            Time.timeScale = 1;
        } else if (Time.timeScale == 1) {
            Time.timeScale = 0;
        }
    }*/
}