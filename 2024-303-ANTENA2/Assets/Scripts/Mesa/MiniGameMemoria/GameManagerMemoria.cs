using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    private GameObject mesaVerde;

    void Update() {
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

    public void StartGame() {

        activeSequence.Clear();

        positionInSequence = 0;
        inputInSequence = 0;

        buttonSelect = Random.Range(0, botoes_telinha.Length);
        
        activeSequence.Add(buttonSelect);

        botoes_telinha[activeSequence[positionInSequence]].color = new Color(255, 255, 255, 1f);

        stayLitCounter = stayLit;
        shouldBeLit = true;
    }

    public void ButtonPressed(int whichButton) {
        if(gameActive) {
            if(activeSequence[inputInSequence] == whichButton) {
                Debug.Log("Correct");

                inputInSequence++;

                if(inputInSequence >= activeSequence.Count) {
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
                gameActive = false;
                mesaVerde = GameObject.Find("Mesa_Verdinha");
                mesaVerde.SetActive(false);

            }
        }
    }
}
