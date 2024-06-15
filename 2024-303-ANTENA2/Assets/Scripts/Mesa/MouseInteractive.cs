using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteractive : MonoBehaviour
{
    [SerializeField] private Color mouseOverHighlightColor = Color.white;
    [SerializeField] private Color selectedHighlightColor = Color.green;
    
    [SerializeField] private SpriteRenderer imgToHighlight;
    private Color imgOriginalColor;
    public bool isSelected { get; private set; }

    private void Start()
    {
        imgOriginalColor = imgToHighlight.color;
    }

    protected void MouseOver()
    {
        Vector2 mouseWorldPos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isSelected) Highlight();
        
        if (IsInside(mouseWorldPos, imgToHighlight.bounds))
        {
            if (Input.GetMouseButtonDown(0)) // Botao esquerdo apertado
                isSelected = true;
            
            Highlight();
        }
        else
        {
            if (Input.GetMouseButtonDown(0)) // Botao esquerdo apertado
                isSelected = false;

            if (!isSelected)
                DesHighlight();
        }
    }


    protected void Highlight() => imgToHighlight.color = isSelected ? selectedHighlightColor : mouseOverHighlightColor;

    protected void DesHighlight() => imgToHighlight.color = imgOriginalColor;

    private static bool IsInside(Vector2 check, Bounds bounds) =>
        check.x <= bounds.max.x && check.x >= bounds.min.x && check.y <= bounds.max.y && check.y >= bounds.min.y;
}
