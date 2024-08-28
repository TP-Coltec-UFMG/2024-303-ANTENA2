using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextBoxAnimation : MonoBehaviour {
    
    public Action TypeFinished;

    public float typeDelay = 0.05f;
    public TextMeshProUGUI textObject;

    public string inicioFrase;
    public string finalFrase;
    [SerializeField] private EscritosSO escritosDocs;
    private string fullText;

    Coroutine coroutine;

    void Awake() {
        fullText = inicioFrase + " " + escritosDocs.nomeDocumento + " " + finalFrase;
        StartTyping();
    }

    public void StartTyping() {
        coroutine = StartCoroutine(TypeText());
    }

    IEnumerator TypeText() {
        textObject.text = fullText;
        textObject.maxVisibleCharacters = 0;
        for (int i = 0; i <= textObject.text.Length; i++) {
            textObject.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeDelay);
        }
        TypeFinished?.Invoke();
    }

    public void Skip() {
        StopCoroutine(coroutine);
        textObject.maxVisibleCharacters = textObject.text.Length;
    }
}