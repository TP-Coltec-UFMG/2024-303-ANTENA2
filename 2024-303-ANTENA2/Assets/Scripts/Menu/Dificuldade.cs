using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dificuldade : MonoBehaviour {
    public static string dificuldade;
    // Start is called before the first frame update
    public void Facil(){
        dificuldade = "facil";
    }
    public void Medio(){
        dificuldade = "medio";
    }
    public void Dificil(){
        dificuldade = "dificil";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
