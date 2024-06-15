using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EditorCentral : MouseInteractive
{
    [SerializeField] private TextMeshPro text;

    private void Update()
    {
        MouseOver();
    }
}
