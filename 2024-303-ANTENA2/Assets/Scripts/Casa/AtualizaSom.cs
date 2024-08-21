using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtualizaSom : MonoBehaviour {
    [SerializeField] private Slider ger;
    [SerializeField] private Slider mus;
    [SerializeField] private Slider efeitos;
    private float defaultVol = 0.25f;
    void Start () {

        AudioListener.volume = PlayerPrefs.GetFloat("Slider_Geral", defaultVol); //definindo como está o volume geral
        ger.value = AudioListener.volume;

        // como está o volume da música
        GameObject[] Musicas = GameObject.FindGameObjectsWithTag("Musica");
        mus.value = PlayerPrefs.GetFloat("Slider_Musica", defaultVol); //definindo no slider
        for(int i = 0; i < Musicas.Length; i++){
            Musicas[i].GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Slider_Musica", defaultVol); //definindo nos audios
        }

        // e dos efeitos
        GameObject[] Efeitos = GameObject.FindGameObjectsWithTag("Efeitos");
        efeitos.value = PlayerPrefs.GetFloat("Slider_Efeitos", defaultVol); //slider
        for(int i = 0; i < Efeitos.Length; i++){
            Efeitos[i].GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Slider_Efeitos", defaultVol); //audios
        }
    }
}
