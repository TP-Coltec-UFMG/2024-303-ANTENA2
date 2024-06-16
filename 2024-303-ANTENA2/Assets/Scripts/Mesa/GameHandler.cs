using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance { get; private set; }
    
    [SerializeField] private int dia;
    [SerializeField] private List<DiaSO> dias;

    private List<MensagemSO> _mensagensDisponiveisDia = new();
    
    private const float TimerNovaMensagemMax = 2f;
    private float _timerNovaMensagemCounter;

    private MensagensChegando _mensagensChegando;
    private EditorCentral _editorCentral;

    public MensagemNova mensagemSelecionada;


    private void Awake()
    {
        Instance ??= this;
    }

    private void Start()
    {
        _mensagensChegando = FindObjectOfType<MensagensChegando>();
        _editorCentral = FindObjectOfType<EditorCentral>();

        _mensagensDisponiveisDia = new List<MensagemSO>(dias[dia - 1].mensagens);
    }

    private void Update()
    {
        NovaMensagemUpdate();

        if (mensagemSelecionada is not null && mensagemSelecionada.IsSelected)
        {
            _editorCentral.Highlight();
            
            if (Input.GetMouseButtonDown(0)) // Botao esquerdo apertado
            {
                _editorCentral.AddMensagem(mensagemSelecionada.Mensagem);
            }
        }
        else
        {
            _editorCentral.DesHighlight();
            mensagemSelecionada = null;
        }
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
        int numMensagensDisponiveis = _mensagensDisponiveisDia.Count;
        if (numMensagensDisponiveis <= 0) return;
        
        MensagemSO mensagem = _mensagensDisponiveisDia[Random.Range(0, numMensagensDisponiveis)];
        _mensagensChegando.AddMensagem(mensagem);
        _mensagensDisponiveisDia.Remove(mensagem);
    }
}
