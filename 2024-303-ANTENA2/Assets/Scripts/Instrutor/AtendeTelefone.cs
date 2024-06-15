using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class AtendeTelefone : MonoBehaviour {
    
    public GameObject PopUp;
    public DialogueSystem dialogueSystem;
    void Awake() {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }

    void Update() {
        if(Input.GetButtonDown("Fire1")) {
            PopUp.SetActive(true);
            
            dialogueSystem.Next();
            
        }
    }
}
