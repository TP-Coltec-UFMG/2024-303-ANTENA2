using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Faz o toc toc toc do personagem andando no chão de madeira
public class FootstepsScript : MonoBehaviour
{
    public AudioSource footstepsSound;
    void Update(){
        if(Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f){
            footstepsSound.enabled = true;
        } else {
            footstepsSound.enabled = false;
        }
    }
}
