using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

    private MensagensChegando _mensagensChegando;

    public int NumOfPages { get; private set; }
    public int CurrPage { get; private set; }

    private new void Start()
    {
        base.Start();
        _mensagensChegando = FindObjectOfType<MensagensChegando>();
        CifrasMesa.OnClick += ClicouCifra;
        
        OnPageChange += (_, _) => paginasText.text = $"P. {CurrPage}/{NumOfPages}";
    }
    
    private void Update()
    {
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
    }

    public void AddMensagem(MensagemSO mensagemSO)
    {
        HasMensagem = true;
        _mensagemSO = mensagemSO;
        frequenciaText.text = "F: " + mensagemSO.frequencia;
        chaveText.text = "C: " + mensagemSO.chave;

        CurrPage = 1;
        NumOfPages = 1 + mensagemSO.mensagem.Length /
                     (CanvasMSG.Instance.GetNumColsRows().x * CanvasMSG.Instance.GetNumColsRows().y);
        
        paginasText.text = $"P. {CurrPage}/{NumOfPages}";

        foreach (string frase in mensagemSO.mensagem.Split('\n'))
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

    public void RemoveMensagem()
    {
        if (!HasMensagem) return;

        HasMensagem = false;
        _mensagemSO = null;
        frequenciaText.text = chaveText.text = paginasText.text = "";
        OnRemoveMessage?.Invoke(this, null);
        _frases.Clear();
    }

    private void ClicouCifra(TipoCifra tipoCifra)
    {
        if (!HasMensagem) return;

        // mensagemText.color = _frases[0].TipoCifra == tipoCifra ? Color.black : Color.gray;
    }
    
    // private static Color TipoCifraToColor(TipoCifra tipoCifra)
    // {
    //     return tipoCifra switch
    //     {
    //         TipoCifra.Azul => new Color(40 / 255f, 57 / 255f, 103 / 255f),
    //         TipoCifra.Amarelo => new Color(151 / 255f, 109 / 255f, 62 / 255f),
    //         TipoCifra.Vermelho => new Color(129 / 255f, 48 / 255f, 57 / 255f),
    //         TipoCifra.Roxo => new Color(104 / 255f, 56 / 255f, 138 / 255f),
    //         TipoCifra.Verde => new Color(52 / 255f, 116 / 255f, 82 / 255f),
    //         _ => Color.black
    //     };
    // }
    
}

public struct Frase
{
    public string Text;
    public TipoCifra TipoCifra;
}
