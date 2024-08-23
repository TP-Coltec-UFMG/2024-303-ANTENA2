using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesligaTelefone : MonoBehaviour {
    public DialogueSystem dialogueSystem;
    [SerializeField] private GameObject telefoneGancho;
    [SerializeField] private Button Next;

    void Awake() {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }
    
    private void OnMouseDown() {
        if (telefoneGancho.activeInHierarchy == false) {
            Next.gameObject.SetActive(false);
            dialogueSystem.SkipInstrutor();
            gameObject.SetActive(false);
            telefoneGancho.SetActive(true);
            
        }
    }
}
