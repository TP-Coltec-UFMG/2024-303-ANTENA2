using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ESTADO {
   DESATIVADO,
   ESPERANDO,
   DIGITANDO
}

public class DialogueSystem : MonoBehaviour {
    
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

    public void btnNext() {
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
            finalizado = false;
        }
        
    }

   void Digitando() {
        typeText.Skip();
        estado = ESTADO.ESPERANDO;
   }

   public void SkipInstrutor() {
        dialogueUI.Disable();
        estado = ESTADO.DESATIVADO;
        textoAtual = 0;
        finalizado = true;
    }
}
