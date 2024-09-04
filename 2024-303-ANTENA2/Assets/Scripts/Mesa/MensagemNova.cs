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
    [SerializeField] private SpriteRenderer bg;
    [SerializeField] private SpriteRenderer bg1;

    private bool _hidden;

    private void Update()
    {
        if (_hidden) return;
        
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
        // text.text = mensagem.mensagem;
    }

    public void Hide(bool state)
    {
        _hidden = state;
        text.enabled = bg.enabled = bg1.enabled = !state;
    }
}
