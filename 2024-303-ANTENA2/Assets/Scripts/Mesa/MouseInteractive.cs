using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteractive : MonoBehaviour
{
    private Color mouseOverHighlightColor = new(185 / 255f, 199 / 255f, 173 / 255f);
    private Color selectedHighlightColor = new(171 / 255f, 96 / 255f, 172 / 255f);
    
    [SerializeField] protected SpriteRenderer imgToHighlight;
    private Color _imgOriginalColor;
    
    public bool IsHighlighted { get; protected set; }
    public bool IsSelected { get; protected set; }

    protected void Start()
    {
        _imgOriginalColor = imgToHighlight.color;
    }

    protected bool MouseOver()
    {
        // mouse world position
        Vector2 mwp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Bounds imgB = imgToHighlight.bounds;

        return mwp.x <= imgB.max.x && mwp.x >= imgB.min.x && mwp.y <= imgB.max.y && mwp.y >= imgB.min.y;
    }


    protected void Highlight()
    {
        imgToHighlight.color = IsSelected ? selectedHighlightColor : mouseOverHighlightColor;
        IsHighlighted = true;
    }

    protected void DesHighlight()
    {
        imgToHighlight.color = _imgOriginalColor;
        IsHighlighted = false;
    }
}
