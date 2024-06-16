using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EditorCentral : MouseInteractive
{
    [SerializeField] private TextMeshPro frequencia;
    [SerializeField] private TextMeshPro chave;
    [SerializeField] private TextMeshPro mensagem;


    public void AddMensagem(MensagemSO mensagemSO)
    {
        frequencia.text = " F: " + mensagemSO.frequencia;
        chave.text = " C: " + mensagemSO.chave;
        mensagem.text = mensagemSO.mensagem;
    }
}
