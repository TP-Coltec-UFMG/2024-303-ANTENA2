using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Text;
using System.Linq;

public class ChavesDeSeguranca : MonoBehaviour
{
    public TextMeshProUGUI textMesh0, textMesh1, textMesh2, textMesh3;
    [SerializeField] private ChavesDeSeguranca chaveSegurancaInstance;
    private int[] chaveString = new int[4];
    public string[] chavesArray = new string[4];

    public static ChavesDeSeguranca Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
        
        for (int i = 0; i < chavesArray.Length; i++)
        {
            chaveString = GeraChave();
            StringBuilder sb = new StringBuilder();

            foreach (int n in chaveString)
            {
                sb.Append(n);
            }

            chavesArray[i] = sb.ToString();
        }

        textMesh0.text = GameHandler.Dia == 1 ? "" : chavesArray[0];
        textMesh1.text = GameHandler.Dia == 1 ? "" : chavesArray[1];
        textMesh2.text = GameHandler.Dia == 1 ? "" : chavesArray[2];
        textMesh3.text = GameHandler.Dia == 1 ? "" : chavesArray[3];
    }

    

    public int[] GeraChave()
    {
        int[] numeros = new int[4];
        int i;
        for (i = 0; i < numeros.Length; i++)
        {
            numeros[i] = Random.Range(0, 10);
        }

        return numeros;
    }

    public string retornaChave()
    {
        var i = Random.Range(0,20);
        var n = Random.Range(0,4);

        if(i == 0)
        {
            var aux = Random.Range(0, 10000).ToString();
            Debug.Log("Chave: " + aux);
            return aux;
        }
        else
        {
            Debug.Log("Chave: " + chavesArray[n]);
            return chavesArray[n];
        }
    }

    public bool ChecaChave(string chave)
    {
        return chavesArray.Contains(chave);
    }
}
