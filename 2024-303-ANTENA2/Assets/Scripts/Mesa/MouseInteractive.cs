using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteractive : MonoBehaviour
{
    [SerializeField] private Color mouseOverHighlightColor = Color.white;
    [SerializeField] private Color selectedHighlightColor = Color.green;
    
    [SerializeField] protected SpriteRenderer imgToHighlight;
    private Color _imgOriginalColor;
    
    public bool IsHighlighted { get; protected set; }
    public bool IsSelected { get; protected set; }

    protected void Start()
    {
        _imgOriginalColor = imgToHighlight.color;
    }

    public bool MouseOver()
    {
        // mouse world position
        Vector2 mwp = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Bounds imgB = imgToHighlight.bounds;

        return mwp.x <= imgB.max.x && mwp.x >= imgB.min.x && mwp.y <= imgB.max.y && mwp.y >= imgB.min.y;
    }


    public void Highlight()
    {
        imgToHighlight.color = IsSelected ? selectedHighlightColor : mouseOverHighlightColor;
        IsHighlighted = true;
    }

    public void DesHighlight()
    {
        imgToHighlight.color = _imgOriginalColor;
        IsHighlighted = false;
    }
}
