using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
    private SpriteRenderer theSprite;
    private GameManagerMemoria gameManagerMemoria;
    private Animator animator;

    [SerializeField] private int buttonNumber;
    void Start() {
        theSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        gameManagerMemoria = GameObject.Find("BotoesTelinha_MiniGame").GetComponent<GameManagerMemoria>();
        animator.enabled = false;
    }

    void OnMouseDown() {
        gameManagerMemoria.botoes_telinha[buttonNumber].color = new Color(255, 255, 255, 1f);
        animator.enabled = true;
    }

    void OnMouseUp() {
        gameManagerMemoria.botoes_telinha[buttonNumber].color = new Color(255, 255, 255, 0f);
        animator.enabled = false;

        gameManagerMemoria.ButtonPressed(buttonNumber);
    }

}
