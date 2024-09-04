using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dificuldade : MonoBehaviour {
    public static string dificuldade;
    [SerializeField] private Button facil;
    [SerializeField] private Button medio;
    [SerializeField] private Button dificil;
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
        //marca o selecionado deixando-o mais escuro
        if(Dificuldade.dificuldade == "facil"){
            facil.GetComponent<Image>().color = new Color(0f/255f, 108f/255f, 2f/255f, 163f/255f);
            medio.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            dificil.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        } else if(Dificuldade.dificuldade == "medio"){
            medio.GetComponent<Image>().color = new Color(192f/255f, 183f/255f, 0f/255f, 193f/255f);
            dificil.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            facil.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        } else if(Dificuldade.dificuldade == "dificil"){
            dificil.GetComponent<Image>().color = new Color(125f/255f, 1f/255f, 0f/255f, 186f/255f);
            medio.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            facil.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
    }
}
