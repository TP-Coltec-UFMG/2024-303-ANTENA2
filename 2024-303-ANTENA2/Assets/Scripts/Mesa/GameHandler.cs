using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance { get; private set; }
    
    // PRECISA DOS DOIS DIAS POR FAVOR NAO TIRA
    public int dia;
    public static int Dia;
    [SerializeField] private List<DiaSO> dias;

    private List<MensagemSO> _mensagensDisponiveisDia = new();
    
    private const float TimerNovaMensagemMax = 10f;
    private float _timerNovaMensagemCounter;

    private MensagensChegando _mensagensChegando;
    private EditorCentral _editorCentral;

    public MensagemNova mensagemSelecionada;


    private void Awake()
    {
        Dia = Dia == 0 ? dia : Dia;
        Instance ??= this;
    }

    private void Start()
    {
        dia = Dia;
        
        _mensagensChegando = FindObjectOfType<MensagensChegando>();
        _editorCentral = FindObjectOfType<EditorCentral>();

        _mensagensDisponiveisDia = new List<MensagemSO>(dias[dia - 1].mensagens);
    }

    private void Update()
    {
        #region Teste Fios
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MiniGames.Instance.StartFios();
        }
        
        #endregion
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
        int numMensagensDisponiveis = _mensagensDisponiveisDia.Count;
        if (numMensagensDisponiveis <= 0) return;
        
        MensagemSO mensagem = _mensagensDisponiveisDia[Random.Range(0, numMensagensDisponiveis)];
        _mensagensChegando.AddMensagem(mensagem);
        _mensagensDisponiveisDia.Remove(mensagem);
    }
}
