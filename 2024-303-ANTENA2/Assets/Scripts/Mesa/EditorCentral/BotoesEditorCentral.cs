using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BotoesEditorCentral : MouseInteractive
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] private TipoBotao tipoBotao;
    
    
    private EditorCentral _editorCentral;


    private new void Start()
    {
        base.Start();
        
        _editorCentral = GetComponentInParent<EditorCentral>();
        text.gameObject.SetActive(false);
    }

    private void Update()
    {
        text.gameObject.SetActive(/* if */ _editorCentral.HasMensagem);

        if (MouseOver() && _editorCentral.HasMensagem)
        {
            Highlight();
            
            if (Input.GetMouseButtonDown(0))
            {
                _editorCentral.RemoveMensagem();
            }
        }
        else
        {
            DesHighlight();
        }
    }
    
    
    private enum TipoBotao
    {
        Aprova,
        Desaprova,
        Denuncia
    }
}
