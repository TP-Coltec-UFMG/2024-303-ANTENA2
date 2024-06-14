using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class MensagemNova : MonoBehaviour
{
    private MensagemSO _mensagem;
    [SerializeField] private TextMeshPro text;

    
    public void SetMensagem(MensagemSO mensagem)
    {
        _mensagem = mensagem;

        const int numChars = 15;
        text.text = mensagem.mensagem[..numChars] + "...";
    }
}
