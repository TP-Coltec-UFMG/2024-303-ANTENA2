using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaLegendasInicio : MonoBehaviour {
    
    [SerializeField] private DialogueData dialogueData;
    int textoAtual = 0;
    bool finalizado = false;

    [SerializeField] private TypeTextAnimation typeText;
    [SerializeField] private DialogueUI dialogueUI;
    ESTADO estado;

    void Awake() {
        typeText = FindObjectOfType<TypeTextAnimation>();
        dialogueUI = FindObjectOfType<DialogueUI>();
        typeText.TypeFinished = OnTypeFinish;
    }

    void Start() {
        estado = ESTADO.DESATIVADO;
    }

    public void Next() {
        if(textoAtual == 0) {
            dialogueUI.Enable();
        }
        
        typeText.fullText = dialogueData.talkScript[textoAtual++].text;
        
        if (textoAtual == dialogueData.talkScript.Count) {
            finalizado = true;
        }
        typeText.StartTyping();
        estado = ESTADO.DIGITANDO;
    }

    public void BtnNext() {
        if (estado == ESTADO.DESATIVADO) return;

        switch(estado) {
            case ESTADO.ESPERANDO:
                Esperando();
                break;
            case ESTADO.DIGITANDO:
                Digitando();
                break;
        }
    }

    void OnTypeFinish() {
        estado = ESTADO.ESPERANDO;
    }

    public void Esperando() {
        if(!finalizado) {
            Next();
        }
        else {
            dialogueUI.Disable();
            estado = ESTADO.DESATIVADO;
            textoAtual = 0;
            finalizado = true;
            SceneManager.LoadScene("Casa");
            Debug.Log("Abrir Jogo");
        }
        
    }

   void Digitando() {
        typeText.Skip();
        estado = ESTADO.ESPERANDO;
   }

   public void Skip() {
        dialogueUI.Disable();
        estado = ESTADO.DESATIVADO;
        textoAtual = 0;
        finalizado = true;
        SceneManager.LoadScene("Casa");
        Debug.Log("Abrir Jogo");
    }
}
