using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class OnHover : MonoBehaviour
{
    private SpriteRenderer rend;
    private Sprite protSprite, tritSprite, deutSprite, nadaSprite;
    public Botao botoes;
    public int filtroAtual;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        if (rend == null)
        {
            Debug.LogError("SpriteRenderer component not found on " + gameObject.name);
        }
        
        /*protSprite = Resources.Load<Sprite>("Images/Configuracoes/hover0");
        tritSprite = Resources.Load<Sprite>("Images/Configuracoes/hover0"); // Provide correct path
        deutSprite = Resources.Load<Sprite>("Images/Configuracoes/hover0"); // Provide correct path
        nadaSprite = Resources.Load<Sprite>("Images/Configuracoes/hover0"); // Provide correct path

        if (protSprite == null || tritSprite == null || deutSprite == null || nadaSprite == null)
        {
            Debug.LogError("One or more sprites could not be loaded. Check the paths.");
        }*/
    }

    void OnMouseEnter() 
    {
        if (rend != null)
        {
            rend.enabled = true;
            
            /*switch (botoes) 
            {
                case Botao.Deuteranopia:
                    rend.sprite = deutSprite;
                    Debug.Log("Deuteranopia sprite set.");
                    break;
                case Botao.Protanopia:
                    rend.sprite = protSprite;
                    Debug.Log("Protanopia sprite set.");
                    break;
                case Botao.Tritanopia:
                    rend.sprite = tritSprite;
                    Debug.Log("Tritanopia sprite set.");
                    break;
                case Botao.SemFiltro:
                    rend.sprite = nadaSprite;
                    Debug.Log("SemFiltro sprite set.");
                    break;
                default:
                    rend.sprite = nadaSprite;
                    Debug.Log("Default sprite set.");
                    break;
            }*/
        }
    }

    void OnMouseExit() 
    {
        if (rend != null)
        {
            rend.enabled = false;
            Debug.Log("SpriteRenderer disabled.");
        }
    }

    public enum Botao
    {
        Deuteranopia,
        Protanopia,
        Tritanopia,
        SemFiltro
    }
}