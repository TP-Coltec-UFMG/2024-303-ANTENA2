using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class AtendeTelefone : MonoBehaviour {
    public DialogueSystem dialogueSystem;
    [SerializeField] private GameObject telefoneFora;
    
    void Awake() {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Return)) {
            dialogueSystem.Next();   
        }
    }

    private void OnMouseDown() {
        if(dialogueSystem != null) {
            Debug.Log("clicou");
            gameObject.SetActive(false);
            telefoneFora.SetActive(true);
            dialogueSystem.Next();
        }
    }
}
