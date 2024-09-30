using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AtivadorDia4 : MonoBehaviour {
    [SerializeField] private float tempo;
    [SerializeField] private float horizontalRange; // adjust this value to change the horizontal detection range
    [SerializeField] private float verticalRange; // adjust this value to change the vertical detection range
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject textBox;
    private bool eventoTerminado;
    void Start() {
        if(GameHandler.Dia == 4) {
            Debug.Log("Dia 4");
        }
    }

    void Update() {
        if(GameHandler.Dia == 4) {
            if (tempo >= 0.0f) {
                tempo -= Time.deltaTime;
            }
            else if (tempo <= 0.0f) {
                float horizontalDistance = Mathf.Abs(transform.position.x - player.transform.position.x);
                float verticalDistance = Mathf.Abs(transform.position.y - player.transform.position.y);
                
                if (horizontalDistance <= horizontalRange && verticalDistance <= verticalRange) {
                    if(eventoTerminado != true) {
                        eventoTerminado = true;
                        textBox.SetActive(true);
                    }
                }
            } 
        }
    }

    public void OlharFechadura() {
        textBox.SetActive(false);
        SceneManager.LoadScene("Rebeldes4Dia");  
    }
    public void NaoOlharFechadura() {
        textBox.SetActive(false);
    }
}

