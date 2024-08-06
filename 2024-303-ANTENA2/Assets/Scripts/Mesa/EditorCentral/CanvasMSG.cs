using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMSG : MonoBehaviour
{
    public static CanvasMSG Instance { get; private set; }
    
    [SerializeField] private EditorCentral editorCentral;
    [SerializeField] private Transform charTemplate;
    [SerializeField] private GridLayoutGroup gridLayout;
    [SerializeField] private Vector2Int NumColsRows;
    
    [SerializeField] private Sprite[] alfabetoNormal;
    [SerializeField] private Sprite[] cifra1;
    [SerializeField] private Sprite[] cifra2;
    [SerializeField] private Sprite[] cifra3;
    [SerializeField] private Sprite[] cifra4;
    [SerializeField] private Sprite[] cifra5;

    private List<Sprite>[] _pages;
    
    
    public Vector2Int GetNumColsRows() => NumColsRows;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        editorCentral.OnNewMessage += (_, e) => CreatePages(e.Frases);
        editorCentral.OnRemoveMessage += (_, _) =>
        {
            ClearMessage();
            _pages = Array.Empty<List<Sprite>>();
        };
        editorCentral.OnPageChange += (_, _) => DisplayMessage();
    }

    /* mode:
     0 - alfabeto normal
     1 - cifra1
     2 - cifra2
     ...
     */
    private void CreatePages(List<Frase> frases)
    {
        int currPage = 0;
        _pages = new List<Sprite>[editorCentral.NumOfPages];
        _pages[0] = new List<Sprite>();
        
        foreach (Frase frase in frases)
        {
            foreach (char c in frase.Text.ToLower())
            {
                string ch = c switch
                {
                    ' ' or '\n' => "_",
                    ':' => "(2 pontos)",
                    '?' => "(interrogacao)",
                    '"' => "'",
                    _ => c.ToString()
                };

                Sprite[] spriteArr = frase.TipoCifra switch
                {
                    TipoCifra.Cifra1 => cifra1,
                    TipoCifra.Cifra2 => cifra2,
                    TipoCifra.Cifra3 => cifra3,
                    TipoCifra.Cifra4 => cifra4,
                    TipoCifra.Cifra5 => cifra5,
                    // _ => alfabetoNormal
                };
                
                Sprite sprite = "abcdefghijklmnopqrstuvwxyzçáãâàéêíóõôú_".Contains(ch)
                    ? spriteArr.FirstOrDefault(spr => spr.name == ch)
                    : alfabetoNormal.FirstOrDefault(spr => spr.name == ch);
                
                if (sprite is null) continue;

                if (_pages[currPage].Count() >= GetNumColsRows().x * GetNumColsRows().y)
                {
                    currPage++;
                    _pages[currPage] = new List<Sprite>();
                }

                _pages[currPage].Add(sprite);
                // Transform charTransform = Instantiate(charTemplate, transform);
                // charTransform.GetComponent<Image>().sprite = sprite;
                // charTransform.gameObject.SetActive(true);
            }
        }

        DisplayMessage();
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
        
        foreach (Sprite sprite in _pages[editorCentral.CurrPage - 1])
        {
            Transform charTransform = Instantiate(charTemplate, transform);
            charTransform.GetComponent<Image>().sprite = sprite;
            charTransform.gameObject.SetActive(true);
        }
    }
}
