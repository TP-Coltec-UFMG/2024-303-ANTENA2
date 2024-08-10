using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
    [Header("Clock UI")]
    [SerializeField] private TMP_Text clockText;
    [Header("Time in a day")]
    [SerializeField] private float timeInADay = 86400f; //um dia = 86400 segundos
    [Header("How fast Time Should Pass")]
    [SerializeField] private float timeScale = 2.0f;
    [Header("Dia no relógio")]
    [SerializeField] private TMP_Text textoDia;
    private float elapseTime;
    private string nomeCena = "Casa";
    private int idCena = 1;
    private int dia = GameHandler.Dia; //não funciona

    private void Start() {
        elapseTime = 9 * 3600f; //9h horário que começa o turno
        string dayString = string.Format("0ia {00}", dia);
        textoDia.text = dayString; //Definindo o dia no relógio
    }

    private void Update() {
        elapseTime += Time.deltaTime * timeScale;
        elapseTime %= timeInADay;
        UpdateClockUI();

        // Às 18h acaba o turno de trabalho e troca para a cena da casa
        if (elapseTime >= (18 * 3600)){
            //fadeIn "cabou trabaio"
            ChangeScene(idCena);
            //fadeOut 'cabou trabaio"
        }
    }

    void UpdateClockUI(){
        int hours = Mathf.FloorToInt(elapseTime / 3600f);
        int minutes = Mathf.FloorToInt((elapseTime - hours * 3600f) / 60f);
        int seconds = Mathf.FloorToInt((elapseTime - hours * 3600f) - ( minutes * 60f));

        string clockString = string.Format("{00:00}:00", hours);
        clockText.text = clockString;
    }
    public void ChangeScene(int num)
    {
        SceneManager.LoadScene(num);
    }
}