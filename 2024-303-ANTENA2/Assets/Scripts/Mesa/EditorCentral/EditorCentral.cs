using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EditorCentral : MouseInteractive
{
    public event EventHandler<OnNewMessageEventArguments> OnNewMessage;
    public class OnNewMessageEventArguments : EventArgs
    {
        public List<Frase> Frases;
    }

    public event EventHandler OnRemoveMessage;
    public event EventHandler OnPageChange;
    
    
    public bool HasMensagem { get; private set; }
    private MensagemSO _mensagemSO;
    private List<Frase> _frases = new();
    [SerializeField] private TextMeshPro frequenciaText;
    [SerializeField] private TextMeshPro chaveText;
    [SerializeField] private TextMeshPro paginasText;
    [SerializeField] private ChavesDeSeguranca chaveSegurancaInstance;

    private MensagensChegando _mensagensChegando;

    public int NumOfPages { get; private set; }
    public int CurrPage { get; private set; }

    public static int NumMensagensRebeldes;
    public static int NumMensagensRebeldesDenunciadas;
    public static int NumMensagensRebeldesEncaminhadas; // Pelo botao dos rebeldes
    public static int NumMensagensLegais; // Legais de legalidade
    public static int NumMensagensLegaisAprovadas; // Legais de legalidade
    
    public static int NumErros;
    private int _toleranciaErros;

    
    private new void Start()
    {
        base.Start();

        NumErros = 0;
        
        _mensagensChegando = FindObjectOfType<MensagensChegando>();
        
        OnPageChange += (_, _) => paginasText.text = $"P. {CurrPage}/{NumOfPages}";
        BotoesEditorCentral.OnSendMessage += OnSendMessage;
    }
    
    private void Update()
    {
        _toleranciaErros = Dificuldade.dificuldade switch
        {
            "facil" => 7,
            "dificil" => 3,
            _ => 5
        };
        
        GameHandler gh = GameHandler.Instance;
        if (gh.mensagemSelecionada is not null && gh.mensagemSelecionada.IsSelected && !HasMensagem)
        {
            Highlight();

            if (!(MouseOver() && Input.GetMouseButtonDown(0))) return; // Botao esquerdo apertado
            AddMensagem(gh.mensagemSelecionada.Mensagem);
            _mensagensChegando.RemoveMensagem(gh.mensagemSelecionada.Mensagem);

            gh.mensagemSelecionada = null;
        }
        else
        {
            DesHighlight();
            gh.mensagemSelecionada = null;
        }

        if (HasMensagem && MouseOver())
        {
            switch (Input.mouseScrollDelta.y)
            {
                case > 0:
                {
                    if (CurrPage > 1) CurrPage--;
                    OnPageChange?.Invoke(this, null);
                    break;
                }
                case < 0:
                {
                    if (CurrPage < NumOfPages) CurrPage++;
                    OnPageChange?.Invoke(this, null);
                    break;
                }
            }
        }

        if (NumErros >= _toleranciaErros)
        {
            // Debug.Log("PERDEU MANE, PERDEU");
            // SceneManager.LoadScene("Mesa");
            AtivaFinais.QualFinal = 3;
            SceneManager.LoadScene("Final");
        }
    }

    public void AddMensagem(MensagemSO mensagemSO)
    {
        HasMensagem = true;
        _mensagemSO = mensagemSO;
        frequenciaText.text = "F: " + mensagemSO.frequencia;

        if (GameHandler.Dia != 1)
        {
            chaveText.text = "C: " + chaveSegurancaInstance.retornaChave();
        }
        else
        {
            chaveText.text = "C: ";
        }
        string newMensagem = "";
        foreach (char c in mensagemSO.mensagem)
        {
            newMensagem += c;
            if (".!?,:;'\"".Contains(c))
            {
                newMensagem += '\n';
            }
        }

        CurrPage = 1;
        NumOfPages = 1 + mensagemSO.mensagem.Length /
            (CanvasMSG.Instance.GetNumColsRows().x * CanvasMSG.Instance.GetNumColsRows().y);

        paginasText.text = $"P. {CurrPage}/{NumOfPages}";

        foreach (string frase in newMensagem.Split('\n'))
        {
            Array tiposCifra = Enum.GetValues(typeof(TipoCifra));
            Frase f = new()
            {
                Text = frase,
                TipoCifra = (TipoCifra)tiposCifra.GetValue(Random.Range(1, tiposCifra.Length))
            };
            _frases.Add(f);
        }

        OnNewMessage?.Invoke(this, new OnNewMessageEventArguments() { Frases = _frases });
        // mensagemText.text = _frases[0].Text;
        // mensagemText.text = _mensagemSO.mensagem;
        // mensagemText.color = TipoCifraToColor(_frases[0].TipoCifra);
    }

    private void OnSendMessage(TipoBotaoSM tipoBotaoSm)
    {
        if (tipoBotaoSm == TipoBotaoSM.Rebelde && _mensagemSO.ehRebelde)
        {
            NumMensagensRebeldes++;
            NumMensagensRebeldesEncaminhadas++;
            
            RemoveMensagem();
            return;
        }
        
        bool rangeFrequencia = _mensagemSO.frequencia is > 100f and < 140f;
        bool frequenciaCorreta = _mensagemSO.frequencia == Frequencias.Instance.frequencia;
        bool ehGoverno = !_mensagemSO.ehRebelde;
        bool chaveCorreta = GameHandler.Dia == 1 || ChavesDeSeguranca.Instance.ChecaChave(_mensagemSO.chave);
        
        // casos que tem que aprovar
        bool aprovar = rangeFrequencia && frequenciaCorreta && ehGoverno && chaveCorreta;
        
        // casos que tem que negar
        bool negar = (!rangeFrequencia || !frequenciaCorreta || !chaveCorreta) && ehGoverno;
        
        // casos que tem que denunciar
        bool denunciar = !ehGoverno;


        if (!ehGoverno)
        {
            NumMensagensRebeldes++;
        }
        
        if (aprovar)
        {
            NumMensagensLegais++;
            if (tipoBotaoSm == TipoBotaoSM.Aprova)
            {
                NumMensagensLegaisAprovadas++;
            }
            else
            {
                NumErros++;
            }
        } 
        else if (negar)
        {
            if (tipoBotaoSm != TipoBotaoSM.Desaprova)
                NumErros++;
        }
        else if (denunciar)
        {
            if (tipoBotaoSm != TipoBotaoSM.Denuncia)
                NumErros++;
            else
                NumMensagensRebeldesDenunciadas++;
        }
        
        
        RemoveMensagem();
    }

    public void RemoveMensagem()
    {
        if (!HasMensagem) return;

        HasMensagem = false;
        _mensagemSO = null;
        frequenciaText.text = chaveText.text = paginasText.text = "";
        OnRemoveMessage?.Invoke(this, null);
        _frases.Clear();
    }
}

public struct Frase
{
    public string Text;
    public TipoCifra TipoCifra;
}
