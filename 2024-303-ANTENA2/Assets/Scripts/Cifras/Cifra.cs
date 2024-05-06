using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cifra : MonoBehaviour
{
    [SerializeField] private TextMeshPro tmp;

    public void SetText(string text)
    {
        tmp.text = text;
    }
}
