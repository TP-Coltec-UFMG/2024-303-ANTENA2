using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleVolume : MonoBehaviour
{
    public static float volumeGeral = 0.5f;
    public static float volumeMusica = 0.25f;
    public static float volumeEfeito = 1.0f;

    public void Update(){
        SaveSliderValue();
    }
    public void VolumeGeral(float volume) {
        volumeGeral = volume;
        AudioListener.volume = volumeGeral;
        //PlayerPrefs.SetFloat("Slider_Geral", volumeGeral);
    }

    public void VolumeMusica(float volume) {
        volumeMusica = volume;
        GameObject[] Musicas = GameObject.FindGameObjectsWithTag("Musica");
        for(int i = 0; i < Musicas.Length; i++){
            Musicas[i].GetComponent<AudioSource>().volume = volumeMusica;
        }
        //PlayerPrefs.SetFloat("Slider_Musica", volumeMusica);
    }

    public void VolumeEfeitos(float volume) {
        volumeEfeito = volume;
        GameObject[] Efeitos = GameObject.FindGameObjectsWithTag("Efeitos");
        for(int i = 0; i < Efeitos.Length; i++){
            Efeitos[i].GetComponent<AudioSource>().volume = volumeEfeito;
        }
        //PlayerPrefs.SetFloat("Slider_Efeitos", volumeEfeito);
    }
    void SaveSliderValue() {
        PlayerPrefs.SetFloat("Slider_Geral", volumeGeral);
        PlayerPrefs.SetFloat("Slider_Musica", volumeMusica);
        PlayerPrefs.SetFloat("Slider_Efeitos", volumeEfeito);
    }
}
