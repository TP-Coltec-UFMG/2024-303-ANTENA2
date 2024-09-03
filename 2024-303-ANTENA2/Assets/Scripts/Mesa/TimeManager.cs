using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
    [SerializeField] private GameObject textoRelogio;
    [SerializeField] private float timeInADay = 86400f; //um dia = 86400 segundos
    [Header("How fast Time Should Pass")]
    [SerializeField] private float timeScale = 2.0f;
    [Header("Dia no relógio")]
    [SerializeField] private TMP_Text textoDia;
    [SerializeField] private TMP_Text textoDiaTrans;
    [SerializeField] private Animator FadeOutDia;
    [SerializeField] private Animator FadeInTrab;
    [SerializeField] private GameObject tuto;
    private bool desligadorApertado = false;
    public static float elapseTime = 0;
    private string nomeCena = "Casa";
    private int dia = 0;
    private float nextActionTime = 0.0f;
    public float period = 0.5f;

    private void Start() {
        dia = GameHandler.Dia;
        textoDiaTrans.text = dia.ToString();
        FadeOutDia.Play("FadeOutDia 0");
        elapseTime = 9 * 3600f; //9h horário que começa o turno
        string dayString = string.Format("0ia {00}", dia);
        textoDia.text = dayString; //Definindo o dia no relógio
    }

    private void Update() {
        //colocando dificuldade: difícil = mais rápido; fácil = mais lento.
        if (Dificuldade.dificuldade == "facil") {
            timeScale = 75f;
        } else if (Dificuldade.dificuldade == "dificil") {
            timeScale = 90f;
        } else if (Dificuldade.dificuldade == "medio"){
            timeScale = 80f;
        }
        //se o tutorial estiver aberto o tempo não passa
        if (!tuto.activeSelf) {

            elapseTime += Time.deltaTime * timeScale;
            elapseTime %= timeInADay;
            UpdateClockUI();

            //quando for 17h o horário começa a piscar para indicar que o turno está acabando
            if (elapseTime >= (17 * 3600) && elapseTime < (18 * 3600)) {
                if (Time.time > nextActionTime ) {
                    nextActionTime += period;
                    if(textoRelogio.activeSelf){
                        textoRelogio.SetActive(false);
                    } else {
                        textoRelogio.SetActive(true);
                    }
                }
            }
            
            //Acrescentar aqui o caso do player apertar o botão para terminar o turno

            // Às 18h acaba o turno de trabalho e troca para a cena da casa, ou o jogador terminou as msgs e apertou o botao de desligar
            if (elapseTime > (18 * 3600) || desligadorApertado){
                FadeInTrab.Play("FadeInTrab"); //fade in 'cabou trabaio'
            }

            //Se tiver passado a transição vai para a próxima cena
            if (FadeInTrab.GetCurrentAnimatorStateInfo(0).IsName("FadeInTrab") && !(FadeInTrab.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1f))
            {
                if (GameHandler.Dia == 5)
                {
                    GameHandler.UltimoDia();
                    return;
                }
                
                SceneManager.LoadScene(nomeCena);
            }
        }
    }

    void UpdateClockUI(){
        int hours = Mathf.FloorToInt(elapseTime / 3600f);
        int minutes = Mathf.FloorToInt((elapseTime - hours * 3600f) / 60f);
        int seconds = Mathf.FloorToInt((elapseTime - hours * 3600f) - ( minutes * 60f));

        string clockString = string.Format("{00:00}:00", hours);
        textoRelogio.GetComponent<TextMeshProUGUI>().text = clockString;
    }
    public void DesligadorDesliga(){
        /*if(terminoudetransmitirtudo){
            desligadorApertado = true;
        }*/
    }
}