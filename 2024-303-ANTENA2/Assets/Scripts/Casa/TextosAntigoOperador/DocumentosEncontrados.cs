using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DocumentosEncontrados : MonoBehaviour {
    [SerializeField] private EscritosSO documentos;
    [SerializeField] private TextMeshProUGUI textObject;
    [SerializeField] private GameObject fundoDoc;
    [SerializeField] private GameObject fundoPreto;
    [SerializeField] private GameObject textBox;

    public void AbreDoc() { 
        textBox.SetActive(false);

        fundoPreto.SetActive(true);
        fundoDoc.SetActive(true);

        foreach (var doc in documentos.escritosDocs) {
            if (doc.dia == GameHandler.Dia) {
                textObject.text = doc.escrito;
                Debug.Log(doc.escrito);
                break; // exit the loop once a matching document is found
            }
        }

        // if no matching document is found, handle the case accordingly
        if (textObject.text == "") {
            // you can add your own logic here to handle the case where no matching document is found
            Debug.Log("No matching document found");
        }
    }
    public void FechaDoc() {
        fundoPreto.SetActive(false);
        fundoDoc.SetActive(false);
        textObject.text = "";
    }
}
