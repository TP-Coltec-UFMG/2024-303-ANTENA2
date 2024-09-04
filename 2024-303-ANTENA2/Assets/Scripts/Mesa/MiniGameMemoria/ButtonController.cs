using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
    private SpriteRenderer theSprite;
    private GameManagerMemoria gameManagerMemoria;
    private Animator animator;
    public AudioSource somBotao;

    [SerializeField] private int buttonNumber;
    void Start() {
        theSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        gameManagerMemoria = GameObject.Find("BotoesTelinha_MiniGame").GetComponent<GameManagerMemoria>();
        animator.enabled = false;
    }

    void OnMouseDown() {
        animator.enabled = true;
        somBotao.Play();

        if(gameManagerMemoria.mesaVerde.activeInHierarchy == true) {
            gameManagerMemoria.botoes_telinha[buttonNumber].color = new Color(255, 255, 255, 1f);
        }
    }

    void OnMouseUp() {
        animator.enabled = false;

        if(gameManagerMemoria.mesaVerde.activeInHierarchy == true) {
            gameManagerMemoria.botoes_telinha[buttonNumber].color = new Color(255, 255, 255, 0f);

            gameManagerMemoria.ButtonPressed(buttonNumber);
        }
    }

}
