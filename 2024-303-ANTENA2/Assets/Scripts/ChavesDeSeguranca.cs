using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Text;
using System.Linq;

public class ChavesDeSeguranca : MonoBehaviour
{
    public TextMeshProUGUI textMesh0, textMesh1, textMesh2, textMesh3;
    public static ChavesDeSeguranca instance;
    private int[] chaveString = new int[4];
    public string[] chavesArray = new string[4];

    private void Awake()
    {
        //instance = this;

        for (int i = 0; i < chavesArray.Length; i++)
        {
            chaveString = GeraChave();
            StringBuilder sb = new StringBuilder();

            foreach (int n in chaveString)
            {
                sb.Append(n);
            }

            instance.chavesArray[i] = sb.ToString();
        }

        textMesh0.text = instance.chavesArray[0];
        textMesh1.text = instance.chavesArray[1];
        textMesh2.text = instance.chavesArray[2];
        textMesh3.text = instance.chavesArray[3];
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
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

    /*public static string retornaChave()
    {
        return chavesArray[0];
    }
    */
}
