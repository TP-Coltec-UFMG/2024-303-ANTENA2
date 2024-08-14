using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EscritosSO : ScriptableObject
{
    [TextArea(1, int.MaxValue)] public string escrito;
    public int Dia;
}