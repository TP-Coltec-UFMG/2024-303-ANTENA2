using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleVolume : MonoBehaviour
{
    [SerializeField] AudioSource musicaFundo;
    public void VolumeMusica(float valor){
        musicaFundo.volume = valor;
    }
}
