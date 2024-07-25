using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerMemoria : MonoBehaviour {
    
    public SpriteRenderer[] botoes_telinha;
    private int buttonSelect;

    [SerializeField] private float stayLit;
    private float stayLitCounter;

    [SerializeField] private float waitBetweenLights;
    private float waitBetweenCounter;

    private bool shouldBeLit;
    private bool shouldBeDark;

    public List<int> activeSequence;
    private int positionInSequence;

    private bool gameActive;
    private int inputInSequence;
    public GameObject mesaVerde;
    public GameObject telaErro;

    private int score;
    [SerializeField] private int maxScore;

    private float erroLit = 0.5F;
    private float erroLitCounter;

    void Update() {
        if (score < maxScore) {
            if(shouldBeLit) {
                stayLitCounter -= Time.deltaTime;

                if (stayLitCounter < 0) {
                    botoes_telinha[activeSequence[positionInSequence]].color = new Color(255, 255, 255, 0f);
                    shouldBeLit = false;

                    shouldBeDark = true;

                    positionInSequence++;
                }
            }
            if(shouldBeDark) {
                waitBetweenCounter -= Time.deltaTime;

                if(positionInSequence >= activeSequence.Count) {
                    shouldBeDark = false;
                    gameActive = true;
                } else {
                    if(waitBetweenCounter < 0) {

                        botoes_telinha[activeSequence[positionInSequence]].color = new Color(255, 255, 255, 1f);

                        stayLitCounter = stayLit;
                        shouldBeLit = true;
                        shouldBeDark = false;
                    }
                }
            }
        }
        else {
            GameEnd();
        }
    }

    public void StartGame() {
        score = 0;
        activeSequence.Clear();

        positionInSequence = 0;
        inputInSequence = 0;

        buttonSelect = Random.Range(0, botoes_telinha.Length);
        
        activeSequence.Add(buttonSelect);

        botoes_telinha[activeSequence[positionInSequence]].color = new Color(255, 255, 255, 1f);

        stayLitCounter = stayLit;
        shouldBeLit = true;
        erroLitCounter = erroLit;

        telaErro.SetActive(false);
    }

    public void ButtonPressed(int whichButton) {
        if(gameActive) {
            if(activeSequence[inputInSequence] == whichButton) {
                Debug.Log("Correct");

                inputInSequence++;

                if(inputInSequence >= activeSequence.Count) {

                    score = activeSequence.Count;

                    positionInSequence = 0;
                    inputInSequence = 0;

                    buttonSelect = Random.Range(0, botoes_telinha.Length);
        
                    activeSequence.Add(buttonSelect);

                    botoes_telinha[activeSequence[positionInSequence]].color = new Color(255, 255, 255, 1f);

                    stayLitCounter = stayLit;
                    shouldBeLit = true;

                    gameActive = false;
                }
            } else {
                Debug.Log("Wrong");
                GameEnd();
                telaErro.SetActive(true);


                if(telaErro.activeInHierarchy == true) {
                    erroLitCounter -= Time.deltaTime;
                    if (erroLitCounter < 0) {
                        telaErro.SetActive(false);
                    }
                }
            }
        }
    }
    private void GameEnd() {
        gameActive = false;
        mesaVerde.SetActive(false);
    }
}

