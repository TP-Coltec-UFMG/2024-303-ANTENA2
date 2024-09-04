using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ESTADO {
   DESATIVADO,
   ESPERANDO,
   DIGITANDO
}

public class DialogueSystem : MonoBehaviour {
    
    [SerializeField] private List<DialogueData> dialogueData;
    int textoAtual = 0;
    bool finalizado = false;
    public AudioSource telefoneDesliga;

    [SerializeField] private TypeTextAnimation typeText;
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private GameObject telefoneFora;
    [SerializeField] private GameObject telefoneGancho;
    [SerializeField] private Button NextBtn;
    ESTADO estado;

    void Awake() {
        typeText = FindObjectOfType<TypeTextAnimation>();
        dialogueUI = FindObjectOfType<DialogueUI>();
        typeText.TypeFinished = OnTypeFinish;
    }

    void Start() {
        estado = ESTADO.DESATIVADO;
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

    public void Next() {
        if(textoAtual == 0) {
            dialogueUI.Enable();
        }
        
        typeText.fullText = dialogueData[1].talkScript[textoAtual++].text;
        
        if (textoAtual == dialogueData[1].talkScript.Count) {
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
            telefoneFora.SetActive(false);
            NextBtn.gameObject.SetActive(false);
            telefoneGancho.SetActive(true);
            dialogueUI.Disable();
            estado = ESTADO.DESATIVADO;
            textoAtual = 0;
            finalizado = false;
            telefoneDesliga.Play();
        }
    }

   void Digitando() {
        typeText.Skip();
        estado = ESTADO.ESPERANDO;
   }

   public void SkipInstrutor() {
        telefoneFora.SetActive(false);
        NextBtn.gameObject.SetActive(false);
        telefoneGancho.SetActive(true);
        dialogueUI.Disable();
        estado = ESTADO.DESATIVADO;
        textoAtual = 0;
        finalizado = false;
    }
}
