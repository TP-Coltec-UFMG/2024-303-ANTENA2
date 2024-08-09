using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CanvasMSG : MonoBehaviour
{
    public static CanvasMSG Instance { get; private set; }
    
    [SerializeField] private EditorCentral editorCentral;
    [SerializeField] private Transform charTemplate;
    [SerializeField] private GridLayoutGroup gridLayout;
    [SerializeField] private Vector2Int numColsRows;
    
    [SerializeField] private Sprite[] alfabetoNormal;
    [SerializeField] private Sprite[] cifra1;
    [SerializeField] private Sprite[] cifra2;
    [SerializeField] private Sprite[] cifra3;
    [SerializeField] private Sprite[] cifra4;
    [SerializeField] private Sprite[] cifra5;

    private List<MSGcharStruct>[] _pages;
    
    
    public Vector2Int GetNumColsRows() => numColsRows;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        editorCentral.OnNewMessage += (_, e) =>
        {
            CreatePages(e.Frases); 
            DisplayMessage();
        };
        editorCentral.OnRemoveMessage += (_, _) =>
        {
            ClearMessage();
            _pages = Array.Empty<List<MSGcharStruct>>();
        };
        editorCentral.OnPageChange += (_, _) => DisplayMessage();

        CanvasMSGChar.OnPointerAnything += (_, e) =>
        {
            List<MSGcharStruct> page = _pages[editorCentral.CurrPage - 1];

            if (e.Selecting)
            {
                for (int i = 0; i < page.Count; i++)
                {
                    CanvasMSGChar canvasMsgChar = transform.GetChild(i + 1).GetComponent<CanvasMSGChar>();
                    canvasMsgChar.ChangeColors(null, null);
                    canvasMsgChar.Selected(false);
                }
            }
            
            for (int i = e.MSGcharStruct.Index; i >= 0; i--)
            {
                if (page[i].TipoCifra == e.MSGcharStruct.TipoCifra)
                {                                         /*+1 por causa do template*/
                    CanvasMSGChar canvasMsgChar = transform.GetChild(i + 1).GetComponent<CanvasMSGChar>();
                    canvasMsgChar.ChangeColors(e.NewCharColor, e.NewBgColor);
                    canvasMsgChar.Selected(e.Selecting);
                }
                else break;
            }
            for (int i = e.MSGcharStruct.Index + 1; i < page.Count; i++)
            {
                if (page[i].TipoCifra == e.MSGcharStruct.TipoCifra)
                {                                         /*+1 por causa do template*/
                    CanvasMSGChar canvasMsgChar = transform.GetChild(i + 1).GetComponent<CanvasMSGChar>();
                    canvasMsgChar.ChangeColors(e.NewCharColor, e.NewBgColor);
                    canvasMsgChar.Selected(e.Selecting);
                }
                else break;
            }
        };

        CifrasMesa.OnClick += tipoCifra =>
        {
            List<MSGcharStruct> page = _pages[editorCentral.CurrPage - 1];
            for (int i = 0; i < page.Count; i++)
            {
                CanvasMSGChar canvasMsgChar = transform.GetChild(i + 1).GetComponent<CanvasMSGChar>();
                if (!(canvasMsgChar.IsSelected && page[i].TipoCifra == tipoCifra)) continue;
                MSGcharStruct msgCharStruct = new()
                {
                    Index = i,
                    Sprite = GetSprite(page[i].Sprite.name, TipoCifra.AlfabetoNormal),
                    TipoCifra = TipoCifra.AlfabetoNormal
                };
                canvasMsgChar.Setup(msgCharStruct);
                page[i] = msgCharStruct;
            }
        };
    }

    private Sprite GetSprite(char c, TipoCifra tipoCifra)
    {
        string ch = c switch
        {
            ' ' => "_",
            ':' => "(2 pontos)",
            '?' => "(interrogacao)",
            '"' => "'",
            _ => c.ToString()
        };

        Sprite[] spriteArr = tipoCifra switch
        {
            TipoCifra.Cifra1 => cifra1,
            TipoCifra.Cifra2 => cifra2,
            TipoCifra.Cifra3 => cifra3,
            TipoCifra.Cifra4 => cifra4,
            TipoCifra.Cifra5 => cifra5,
            TipoCifra.AlfabetoNormal => alfabetoNormal
        };
                
        return "abcdefghijklmnopqrstuvwxyzçáãâàéêíóõôú_".Contains(ch)
            ? spriteArr.FirstOrDefault(spr => spr.name == ch)
            : alfabetoNormal.FirstOrDefault(spr => spr.name == ch);
    }

    private Sprite GetSprite(string ch, TipoCifra tipoCifra)
    {
        Sprite[] spriteArr = tipoCifra switch
        {
            TipoCifra.Cifra1 => cifra1,
            TipoCifra.Cifra2 => cifra2,
            TipoCifra.Cifra3 => cifra3,
            TipoCifra.Cifra4 => cifra4,
            TipoCifra.Cifra5 => cifra5,
            TipoCifra.AlfabetoNormal => alfabetoNormal
        };
                
        return "abcdefghijklmnopqrstuvwxyzçáãâàéêíóõôú_".Contains(ch)
            ? spriteArr.FirstOrDefault(spr => spr.name == ch)
            : alfabetoNormal.FirstOrDefault(spr => spr.name == ch);
    }
    
    private void CreatePages(List<Frase> frases)
    {
        int currPage = 0;
        _pages = new List<MSGcharStruct>[editorCentral.NumOfPages];
        _pages[0] = new List<MSGcharStruct>();

        int charIndexOnFrases = 0;
        foreach (Frase frase in frases)
        {
            for (int i = 0; i < frase.Text.Length; i++)
            // foreach (char c in frase.Text.ToLower())
            {
                char c = frase.Text.ToLower()[i];
                Sprite sprite = GetSprite(c, frase.TipoCifra);
                
                if (sprite is null) continue;

                if (_pages[currPage].Count >= GetNumColsRows().x * GetNumColsRows().y)
                {
                    currPage++;
                    charIndexOnFrases = 0;
                    _pages[currPage] = new List<MSGcharStruct>();
                }

                MSGcharStruct msgChar = new()
                    { Sprite = sprite, TipoCifra = frase.TipoCifra, Index = charIndexOnFrases };
                _pages[currPage].Add(msgChar);

                charIndexOnFrases++;
                // Transform charTransform = Instantiate(charTemplate, transform);
                // charTransform.GetComponent<Image>().sprite = sprite;
                // charTransform.gameObject.SetActive(true);
            }
        }
    }

    private void ClearMessage()
    {
        while (transform.childCount > 1) // >1 pra deixar o template lá
        {
            DestroyImmediate(transform.GetChild(1).gameObject);
        }
    }
    
    private void DisplayMessage()
    {
        ClearMessage();
        
        foreach (MSGcharStruct msgChar in _pages[editorCentral.CurrPage - 1])
        {
            Transform charTransform = Instantiate(charTemplate, transform);
            charTransform.gameObject.GetComponent<CanvasMSGChar>().Setup(msgChar);
            charTransform.gameObject.SetActive(true);
        }
    }
}
