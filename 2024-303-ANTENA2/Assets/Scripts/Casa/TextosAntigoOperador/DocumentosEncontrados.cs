using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DocumentosEncontrados : MonoBehaviour {
    [SerializeField] EscritosSO documentos;
    [SerializeField] TextMeshProUGUI textObject;
    [SerializeField] GameObject fundoDoc;

    void AbreDoc() {
        fundoDoc.SetActive(true);
        textObject.text = documentos.escritosDocs[1].escrito;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
