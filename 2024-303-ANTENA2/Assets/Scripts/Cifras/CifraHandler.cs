using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CifraHandler : MonoBehaviour
{
    [SerializeField] private Cifra cifra;
    [SerializeField] private List<CifraSO> cifras;

    private void Start()
    {
        cifra.SetText(CodificaMensagem(cifras[0]));
    }

    private string CodificaMensagem(CifraSO cifraSO)
    {
        string Numero(string texto)
        {
            string alfabeto = "abcdefghijklmnopqrstuvwxyz";
            texto = texto.ToLower();
            
            StringBuilder sb = new();
            
            foreach (char c in texto)
            {
                if (c == ' ')
                {
                    sb.Append(" | ");
                    continue;
                }

                if (alfabeto.Contains(c))
                {
                    sb.Append(alfabeto.IndexOf(c) + 1);
                    sb.Append(' ');
                    continue;
                }

                sb.Append(c);
                sb.Append(' ');
            }

            return sb.ToString();
        }

        return cifraSO.tipo switch
        {
            TipoCifra.Numero => Numero(cifraSO.mensagem)
        };
    }
}
