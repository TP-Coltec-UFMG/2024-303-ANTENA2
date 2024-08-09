using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Image = UnityEngine.UI.Image;

public class CanvasMSGChar : MonoBehaviour
    , IPointerEnterHandler
    , IPointerExitHandler
    , IPointerDownHandler
{
    [SerializeField] private Image background;
    [SerializeField] private Image character;
    
    private MSGcharStruct _msgChar;
    private bool _isPointerInside;
    private bool _isSelected;


    public static event EventHandler<OnPointerAnythingEventArgs> OnPointerAnything;

    public class OnPointerAnythingEventArgs : EventArgs
    {
        public MSGcharStruct MSGcharStruct;
        public Color NewCharColor;
        public Color NewBgColor;
        public bool Selecting = false;
    }
    
    
    public void Update()
    {
        // if (Input.GetMouseButtonDown(0) && _isSelected && !_isPointerInside)
        // {
        //     OnPointerAnything?.Invoke(this, new OnPointerAnythingEventArgs()
        //     {
        //         MSGcharStruct = _msgChar,
        //         NewCharColor = TipoCifraToColor(_msgChar.TipoCifra),
        //         NewBgColor = Color.clear
        //     });
        // }
    }

    public void Setup(MSGcharStruct msgChar)
    {
        _msgChar = msgChar;
        character.sprite = msgChar.Sprite;
        ChangeColors(TipoCifraToColor(msgChar.TipoCifra), Color.clear);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isPointerInside = true;

        if (_isSelected) return;
        
        OnPointerAnything?.Invoke(this, new OnPointerAnythingEventArgs()
        {
            MSGcharStruct = _msgChar,
            NewCharColor = TipoCifraToColor(_msgChar.TipoCifra),
            NewBgColor = new Color(.5f, .5f, .5f, .2f)
        });
        
        // ChangeColors(TipoCifraToColor(_msgChar.TipoCifra), new Color(.5f, .5f, .5f, .2f));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isPointerInside = false;

        if (_isSelected) return;
        
        OnPointerAnything?.Invoke(this, new OnPointerAnythingEventArgs()
        {
            MSGcharStruct = _msgChar,
            NewCharColor = TipoCifraToColor(_msgChar.TipoCifra),
            NewBgColor = Color.clear
        });

        // ChangeColors(TipoCifraToColor(_msgChar.TipoCifra), Color.clear);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPointerAnything?.Invoke(this, new OnPointerAnythingEventArgs()
        {
            MSGcharStruct = _msgChar,
            NewCharColor = new Color(40 / 255f, 42 / 255f, 54 / 255f),
            NewBgColor = TipoCifraToColor(_msgChar.TipoCifra),
            Selecting = true
        });

        // ChangeColors(new Color(40 / 255f, 42 / 255f, 54 / 255f), TipoCifraToColor(_msgChar.TipoCifra));
    }

    public void ChangeColors(Color? charColor, Color? bgColor)
    {
        Color charC = charColor ?? TipoCifraToColor(_msgChar.TipoCifra);
        Color bgC = bgColor ?? Color.clear;
        character.color = charC;
        background.color = bgC;
    }
    
    private static Color TipoCifraToColor(TipoCifra tipoCifra)
    {
        return tipoCifra switch
        {
            TipoCifra.Cifra1 => new Color(040 * 1.8f / 255f, 057 * 1.8f / 255f, 103 * 1.8f / 255f),
            TipoCifra.Cifra2 => new Color(151 * 1.8f / 255f, 109 * 1.8f / 255f, 062 * 1.8f / 255f),
            TipoCifra.Cifra3 => new Color(129 * 1.8f / 255f, 048 * 1.8f / 255f, 057 * 1.8f / 255f),
            TipoCifra.Cifra4 => new Color(104 * 1.8f / 255f, 056 * 1.8f / 255f, 138 * 1.8f / 255f),
            TipoCifra.Cifra5 => new Color(052 * 1.8f / 255f, 116 * 1.8f / 255f, 082 * 1.8f / 255f),
            // _ => new Color(040 * 1.8f / 255f, 057 * 1.8f / 255f, 103 * 1.8f / 255f)
        };
    }

    public void Selected(bool value) => _isSelected = value;
}

public struct MSGcharStruct
{
    public TipoCifra TipoCifra;
    public Sprite Sprite;
    public int Index;
}
