using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjeto : MonoBehaviour {
    [SerializeField] private Transform player;
    [SerializeField] private GameObject fundoPreto;
    SpriteRenderer spriteRenderer;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if(Mathf.Abs(transform.position.x - player.position.x) < 2.0f) {
            if(Input.GetKeyDown(KeyCode.E)) {
                fundoPreto.setActive(true);
            }
        }
    }
}