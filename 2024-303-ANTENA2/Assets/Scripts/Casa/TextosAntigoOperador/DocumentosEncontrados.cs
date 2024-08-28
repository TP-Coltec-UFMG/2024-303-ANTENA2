using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DocumentosEncontrados : MonoBehaviour {
    [SerializeField] EscritosSO documentos;
    [SerializeField] TextMeshProUGUI textObject;
    [SerializeField] GameObject fundoDoc;
    [SerializeField] GameObject fundoPreto;

    private int i;

    public void AbreDoc() { 
        i = 0;
        fundoPreto.SetActive(false);
        fundoDoc.SetActive(true);
        Debug.Log(i);

        while(documentos.escritosDocs[i].dia != 1 && i < documentos.escritosDocs.Count) {
            Debug.Log(i);
            i++;
        }
        if(documentos.escritosDocs[i].dia == 1) {
            textObject.text = documentos.escritosDocs[i].escrito;
            Debug.Log(i);
            Debug.Log(documentos.escritosDocs[i].escrito);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
