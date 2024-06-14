using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private int dia;
    [SerializeField] private List<DiaSO> dias;

    private List<MensagemSO> _mensagensDisponiveisDia = new();

    private const float TimerNovaMensagemMax = 2f;
    private float _timerNovaMensagemCounter;

    private MensagensChegando _mensagensChegando;

    private void Start()
    {
        _mensagensChegando = FindObjectOfType<MensagensChegando>();
    }

    private void Update()
    {
        NovaMensagemUpdate();
    }


    private void NovaMensagemUpdate()
    {
        if (_timerNovaMensagemCounter >= TimerNovaMensagemMax)
        {
            _timerNovaMensagemCounter = 0;
            
            GeraNovaMensagem();
        }

        _timerNovaMensagemCounter += Time.deltaTime;
    }
    
    private void GeraNovaMensagem()
    {
        List<MensagemSO> mensagensDia = dias[dia - 1].mensagens;
        _mensagensChegando.AddMensagem(mensagensDia[Random.Range(0, mensagensDia.Count)]);
    }
}
