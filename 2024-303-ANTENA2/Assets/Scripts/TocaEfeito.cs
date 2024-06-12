using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TocaEfeito : MonoBehaviour
{
    public AudioSource efeito;
    private void OnMouseDown(){
        efeito.Play();
    }
}
