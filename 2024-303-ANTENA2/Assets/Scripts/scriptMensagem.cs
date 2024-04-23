using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class scriptMensagem : MonoBehaviour
{
    public TextMeshPro texto;
    public float frequencia;
    public int tipoCifra;

    public TMP_FontAsset fontePadrao;
    public TMP_FontAsset cifra_0;
    public TMP_FontAsset cifra_1;
    public TMP_FontAsset cifra_2;
    public TMP_FontAsset cifra_3;
    public TMP_FontAsset cifra_4;
        
    // Start is called before the first frame update
    void Start()
    {
        //Descobre qual a cifra da mensagem e transforma a fonte do texto para
        //a fonte correspondente à cifra;
        switch (tipoCifra)
        {
            case 0:
                texto.font = cifra_0;
                break;
            case 1:
                texto.font = cifra_1;
                break;
            case 2:
                texto.font = cifra_2;
                break;
            case 3:
                texto.font = cifra_3;
                break;
            case 4:
                texto.font = cifra_4;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Recebe o número da cifra que o jogador escolheu e retorna se ela tá correta
    public bool decodificaMensagem(scriptCifra cifraEscolhida)
    {
        if (cifraEscolhida.cifra == tipoCifra)
        {
            //muda a mensagem para a fonte normal
            texto.font = fontePadrao;
            return true;
        }
        else
        {
            return false;
        }
    }

    //Ao detectar uma colisão, verifica se é com um objeto FolhaDeCifra e chama a 
    //função de decodificar usando o scriptCifra da FolhaDeCifra
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Cifra")
        {
            //O retorno do decodifica mensagem pode ser usado depois quando
            //a gente for fazer a parte de drag-and-drop
            scriptCifra cifraAtual = (scriptCifra)collision.gameObject.GetComponent("scriptCifra");
            decodificaMensagem(cifraAtual);
        }
    }
}
