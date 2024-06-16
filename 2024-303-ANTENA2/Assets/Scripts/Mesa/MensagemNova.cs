using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class MensagemNova : MouseInteractive
{
    public MensagemSO Mensagem { get; private set; }
    [SerializeField] private TextMeshPro text;


    private void Update()
    {
        if (IsSelected)
        {
            Highlight();
            GameHandler.Instance.mensagemSelecionada = this;
        }
        
        if (MouseOver())
        {
            if (Input.GetMouseButtonDown(0)) // Botao esquerdo apertado
                IsSelected = true;
            
            Highlight();
        }
        else
        {
            if (Input.GetMouseButtonDown(0)) // Botao esquerdo apertado
                IsSelected = false;

            if (!IsSelected)
                DesHighlight();
        }
    }

    public void SetMensagem(MensagemSO mensagem)
    {
        Mensagem = mensagem;

        const int numChars = 15;
        text.text = mensagem.mensagem[..numChars] + "...";
    }
}
