using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; //para colocarmos nosso personagem como alvo
    void Update(){
    //vamos fazer a câmera seguir o personagem em x e y, mas manter o seu z.
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }

}
