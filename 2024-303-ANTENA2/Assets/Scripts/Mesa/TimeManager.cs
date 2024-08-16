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
    [SerializeField] private TMP_Text textoDiaTrans;
    private float elapseTime = 0;
    private string nomeCena = "Casa";
    private int dia = 0;
    [SerializeField] private Animator FadeOutDia;
    [SerializeField] private Animator FadeInTrab;

    private void Start() {
        dia = GameHandler.Dia;
        textoDiaTrans.text = dia.ToString();
        FadeOutDia.Play("FadeOutDia 0");
        elapseTime = 9 * 3600f; //9h horário que começa o turno
        string dayString = string.Format("0ia {00}", dia);
        textoDia.text = dayString; //Definindo o dia no relógio
    }

    private void Update() {
        elapseTime += Time.deltaTime * timeScale;
        elapseTime %= timeInADay;
        UpdateClockUI();

        // Às 18h acaba o turno de trabalho e troca para a cena da casa
        if (elapseTime > (18 * 3600)){
            FadeInTrab.Play("FadeInTrab"); //fade in 'cabou trabaio'
        }

        //Se tiver passado a transição vai para a próxima cena
        if (FadeInTrab.GetCurrentAnimatorStateInfo(0).IsName("FadeInTrab") && !(FadeInTrab.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1f)){
            SceneManager.LoadScene(nomeCena);
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