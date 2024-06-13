using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MensagemSO : ScriptableObject
{
    [TextArea(1, int.MaxValue)] public string mensagem;
    [SerializeField] private TipoCifra[] tiposDeCifra;
    public float frequencia;
    public float chave;
}

[Serializable]
public enum TipoCifra
{
    Numero,
    LetraAleatoria,
    Simbolos,
    Asteriscos
}