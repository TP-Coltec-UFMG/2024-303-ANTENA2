using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class botaoDoCoisoQueDecide : MonoBehaviour
{
    public int tipoBotao;

    public int botaoPressed;
    // Start is called before the first frame update
    void Start()
    {
        this.GameObject().SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool decideCoiso()
    {
        if (tipoBotao == 0)
        {
            botaoPressed = tipoBotao;
            return true;
        }
        else if (tipoBotao == 1)
        {
            botaoPressed = tipoBotao;
            return false;
        }
        else
        {
            botaoPressed = tipoBotao;
            return false;
        }
    }
}
