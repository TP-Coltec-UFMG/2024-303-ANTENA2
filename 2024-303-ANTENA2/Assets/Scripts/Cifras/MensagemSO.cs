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
    public bool ehRebelde;
    public int ordem;
}

[Serializable]
public enum TipoCifra
{
    AlfabetoNormal,
    Cifra1,
    Cifra2,
    Cifra3,
    Cifra4,
    Cifra5
}
