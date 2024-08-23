using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesligaTelefone : MonoBehaviour {
    public DialogueSystem dialogueSystem;
    [SerializeField] private GameObject telefoneGancho;

    void Awake() {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }
    
    private void OnMouseDown() {
        if (telefoneGancho.activeInHierarchy == false) {
            dialogueSystem.SkipInstrutor();
            gameObject.SetActive(false);
            telefoneGancho.SetActive(true);
        }
    }
}
