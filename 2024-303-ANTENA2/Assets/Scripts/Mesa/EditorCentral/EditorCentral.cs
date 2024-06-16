using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class EditorCentral : MouseInteractive
{
    public bool HasMensagem { get; private set; }
    private MensagemSO _mensagemSO;
    [SerializeField] private TextMeshPro frequenciaText;
    [SerializeField] private TextMeshPro chaveText;
    [SerializeField] private TextMeshPro mensagemText;

    
    public void AddMensagem(MensagemSO mensagemSO)
    {
        HasMensagem = true;
        _mensagemSO = mensagemSO;
        frequenciaText.text = "F: " + mensagemSO.frequencia;
        chaveText.text = "C: " + mensagemSO.chave;
        mensagemText.text = mensagemSO.mensagem;
    }

    public void RemoveMensagem()
    {
        if (!HasMensagem) return;

        HasMensagem = false;
        _mensagemSO = null;
        frequenciaText.text = chaveText.text = mensagemText.text = "";
    }
}
