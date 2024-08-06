using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Posiciona a câmera de acordo com onde está o personagem dentro dos limites da casa

public class CameraController : MonoBehaviour
{
    public Transform target; //para colocarmos nosso personagem como alvo
    private float smoothing = 0.01f;
    /*void Update(){
    //vamos fazer a câmera seguir o personagem em x e y, mas manter o seu z.
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }*/
    public Vector2 minPosition;
    public Vector2 maxPosition;
    void LateUpdate(){
        if (transform.position != target.position){
            Vector3 targetPosition = new Vector3(target.transform.position.x,target.transform.position.y, transform.position.z);

    //clamp in between
        targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);


    //gradualmente move o objeto: posição original, posição alvo, velocidade
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
