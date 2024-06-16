using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MensagemNova : MouseInteractive
{
    private MensagemSO _mensagem;
    [SerializeField] private TextMeshPro text;


    private void Update()
    {
        MouseOver();

        if (isSelected)
            GameHandler.Instance.mensagemSelecionada = this;
    }

    public void SetMensagem(MensagemSO mensagem)
    {
        _mensagem = mensagem;

        const int numChars = 15;
        text.text = mensagem.mensagem[..numChars] + "...";
    }
}
