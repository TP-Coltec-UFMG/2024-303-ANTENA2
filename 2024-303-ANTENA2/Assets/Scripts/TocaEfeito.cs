using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TocaEfeito : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip efeito;
    private void OnCollisionEnter(Collision collision){
        audioSource.PlayOneShot(efeito);
    }
}
