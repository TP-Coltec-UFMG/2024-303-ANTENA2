using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleVolume : MonoBehaviour
{
    public float volumeGeral, volumeMusica, volumeEfeito;
    public void VolumeGeral(float volume){
        volumeGeral = volume;
        AudioListener.volume = volumeGeral;
    }

    public void VolumeMusica(float volume){
        volumeMusica = volume;
        GameObject[] Musicas = GameObject.FindGameObjectsWithTag("Musica");
        for(int i = 0; i < Musicas.Length; i++){
            Musicas[i].GetComponent<AudioSource>().volume = volumeMusica;
        }
    }

    public void VolumeEfeitos(float volume){
        volumeEfeito = volume;
        GameObject[] Efeitos = GameObject.FindGameObjectsWithTag("Efeitos");
        for(int i = 0; i < Efeitos.Length; i++){
            Efeitos[i].GetComponent<AudioSource>().volume = volumeEfeito;
        }
    }
}
