using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BotoesEditorCentral : MouseInteractive
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] private TipoBotao tipoBotao;
    private EditorCentral _editorCentral;

    public static event EventHandler<OnBotaoECPressEventArgs> OnBotaoECPress;

    public class OnBotaoECPressEventArgs : EventArgs
    {
        public TipoBotao tipoBotao;
    }

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
                OnBotaoECPress?.Invoke(this, new OnBotaoECPressEventArgs { tipoBotao =  tipoBotao });
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
    
    public enum TipoBotao
    {
        Aprova,
        Desaprova,
        Denuncia
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
