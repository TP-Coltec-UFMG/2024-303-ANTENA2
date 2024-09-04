using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaneNaMesa : MonoBehaviour {
    [SerializeField] GameObject Relogio;
    private PausaTempo pausaTempo;
    
    [SerializeField] GameObject Slots;
    [SerializeField] GameObject editorCentral;

    void Awake() {
        pausaTempo = Relogio.GetComponent<PausaTempo>();
    }
    public void desligaMesa() {
        pausaTempo.PausarJogo();
        GameHandler.Instance.PausarMensagens(true);
        Slots.SetActive(false);
        DeactivateImmediateChildrenOnly(editorCentral);
    }
    public void ligaMesa() {
        pausaTempo.PausarJogo();
        GameHandler.Instance.PausarMensagens(false);
        Slots.SetActive(true);
        ActivateImmediateChildrenOnly(editorCentral);
    }

    public void DeactivateImmediateChildrenOnly(GameObject parentObject) {
        foreach (Transform child in parentObject.transform) {
            child.gameObject.SetActive(false);
        }
    }
    public void ActivateImmediateChildrenOnly(GameObject parentObject) {
        foreach (Transform child in parentObject.transform) {
            child.gameObject.SetActive(true);
        }
    }
    
}

