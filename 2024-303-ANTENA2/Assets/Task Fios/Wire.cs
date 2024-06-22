using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wire : MonoBehaviour
{
    [SerializeField] private Transform parentTransform;
    public SpriteRenderer wireEnd;
    public GameObject lightOn;
    Vector3 startPoint;
    Vector3 startPosition;
    
    void Start()
    {
        startPoint = transform.parent.position;
        startPosition = transform.position;
    }

    private void OnMouseDrag(){
        //posição do mouse
        Vector3 newPosition = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        //checar se existe conexão por perto
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .02f);

        foreach(Collider2D collider in colliders){
            //olhar se não é seu prórpio collider
            if(collider.gameObject != gameObject){
                //atualiza o fio para ficar no ponto de conexão
                UpdateWire(collider.transform.position);
                //checar se os fios tem a mesma cor
                if(transform.parent.name.Equals(collider.transform.parent.name)){
                    //contar fio como feito
                    Main.Instance.SwitchChange(1);
                    //terminado
                    collider.GetComponent<Wire>()?.Done();
                    Done();
                }
                return;
            }
        }

        //atualizar o fio
        UpdateWire(newPosition);
        
    }
    private void Done(){
        //ligar as luzinhas
        lightOn.SetActive(true);

        //destruir o script
        Destroy(this);
    }
    private void OnMouseUp(){
        //reset wire position
        UpdateWire(startPosition);
    }

    private void UpdateWire(Vector3 newPosition){
        //update wire and position
        transform.position = newPosition;

        //update direction
        Vector3 direction = newPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;

        //update scale
        float distance = Vector2.Distance(startPoint, newPosition) / parentTransform.localScale.x;
        wireEnd.size = new Vector2(distance, wireEnd.size.y);
    }
}
