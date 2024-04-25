using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiltrosDaltonismo : MonoBehaviour
{
    public Toggle toggleNada;
    public Toggle toggleDeuteranopia;
    public Toggle toggleProtanopia;
    public Toggle toggleTritanopia;
    void Start()
    {
        if(PlayerPrefs.GetInt("ToggleBool") == 1){
            toggleNada.isOn = true;
        } else {
            toggleNada.isOn = false;
        }
        
        if(PlayerPrefs.GetInt("ToggleBool2") == 1){
            toggleDeuteranopia.isOn = true;
        } else {
            toggleDeuteranopia.isOn = false;
        }

        if(PlayerPrefs.GetInt("ToggleBool3") == 1){
            toggleProtanopia.isOn = true;
        } else {
            toggleProtanopia.isOn = false;
        }

        if(PlayerPrefs.GetInt("ToggleBool4") == 1){
            toggleTritanopia.isOn = true;
        } else {
            toggleTritanopia.isOn = false;
        }
    }
    void Update()
    {
        if(toggleNada.isOn == true){
            PlayerPrefs.GetInt("ToggleBool", 1);
        } else {
            PlayerPrefs.GetInt("ToggleBool", 0);
        }

        if(toggleDeuteranopia.isOn == true){
            PlayerPrefs.GetInt("ToggleBool", 1);
        } else {
            PlayerPrefs.GetInt("ToggleBool", 0);
        }

        if(toggleProtanopia.isOn == true){
            PlayerPrefs.GetInt("ToggleBool", 1);
        } else {
            PlayerPrefs.GetInt("ToggleBool", 0);
        }

        if(toggleTritanopia.isOn == true){
            PlayerPrefs.GetInt("ToggleBool", 1);
        } else {
            PlayerPrefs.GetInt("ToggleBool", 0);
        }
    }
}
