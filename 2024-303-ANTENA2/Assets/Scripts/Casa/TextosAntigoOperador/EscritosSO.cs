using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public struct EscritosDoc {
    public int dia;
    [TextArea(1, int.MaxValue)] public string escrito;
}

[Serializable] public enum TipoDeDocumento {
    PaginasDiario,
    Cartas,
    CartasPai,
    Notas
}

[CreateAssetMenu(fileName = "EscritosSO", menuName = "ScriptableObjects/DocsAntigoOperador", order = 1)]
public class EscritosSO : ScriptableObject {
    public TipoDeDocumento tipoDeDocumento;
    public string nomeDocumento;
    public List<EscritosDoc> escritosDocs;
}
/*public class EscritosSO : ScriptableObject

{
    [TextArea(1, int.MaxValue)] public string escrito;
    public int Dia;
}*/