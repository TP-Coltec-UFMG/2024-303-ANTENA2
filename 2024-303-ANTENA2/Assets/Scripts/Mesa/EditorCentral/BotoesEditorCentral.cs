using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class BotoesEditorCentral : MouseInteractive
{
    [SerializeField] [CanBeNull] private TextMeshPro text;
    [FormerlySerializedAs("tipoBotao")] [SerializeField] private TipoBotaoSM tipoBotaoSm;
    private EditorCentral _editorCentral;

    public static event Action<TipoBotaoSM> OnSendMessage;
    
    private new void Start()
    {
        base.Start();
        
        _editorCentral = GetComponentInParent<EditorCentral>();
        text?.gameObject.SetActive(false);
    }

    private void Update()
    {
        text?.gameObject.SetActive(/* if */ _editorCentral.HasMensagem);

        if (MouseOver() && _editorCentral.HasMensagem)
        {
            Highlight();
            
            if (Input.GetMouseButtonDown(0))
            {
                OnSendMessage?.Invoke(tipoBotaoSm);
                CursorController.instance.ActivateCursorSelectTap();
            }
            else if(Input.GetMouseButtonUp(0))
            {
                CursorController.instance.ActivateCursorSelect();
            }
        }
        else
        {
            DesHighlight();
        }

        if (MouseOver() && !_editorCentral.HasMensagem)
        {
            CursorController.instance.ActivateCursorDefault();
        }
    }
    
    private void OnMouseExit()
    {
        CursorController.instance.ActivateCursorDefault();
    }

    private void OnMouseEnter()
    {
        CursorController.instance.ActivateCursorSelect();
    }
}


public enum TipoBotaoSM
{
    Aprova,
    Desaprova,
    Denuncia,
    Rebelde
}
