using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controla as animações de andar do personagem

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player;
    [SerializeField] private float speed;
    [SerializeField] private Transform bonecoPorta;
    [SerializeField] private Transform bonecoMesa;
    private Animator myAnimation;

    void Start(){
        player = GetComponent<Rigidbody2D>();
        myAnimation = GetComponent<Animator>();

        if (GameHandler.Dia == 0) {
            transform.position = bonecoPorta.position;
        } else {
            transform.position = bonecoMesa.position;
        }
    }
    void Update(){
        player.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
        myAnimation.SetFloat("moveX", player.velocity.x);
        myAnimation.SetFloat("moveY", player.velocity.y);


//Se estivermos para a direção X, nosso último movimento será para X
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1){
            myAnimation.SetFloat("lastmoveX", Input.GetAxisRaw("Horizontal"));
            myAnimation.SetFloat("lastmoveY", Input.GetAxisRaw("Vertical"));

        }
    }
}
