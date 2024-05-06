using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CifraSO : ScriptableObject
{
    public TipoCifra tipo;
    public float frequencia;
    [TextArea(1, int.MaxValue)]
    public string mensagem;
    [Tooltip("Em porcentagem")] [Range(0, 1)]
    public float chanceDeAparecer;
}

[Serializable]
public enum TipoCifra
{
    Numero,
    LetraAleatoria,
    Simbolos,
    Asteriscos
}
