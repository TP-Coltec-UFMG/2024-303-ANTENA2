using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class OnHover : MonoBehaviour
{
    [SerializeField] private GameObject rend;
    //private Sprite protSprite, tritSprite, deutSprite, nadaSprite;
    //public Botao botoes;
    //public int filtro;

    void Start()
    {
        //rend = GetComponent<SpriteRenderer>();
        //Debug.LogError("SpriteRenderer component not found");
        
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
        rend.SetActive(true);
            
            /*switch (filtro) 
            {
                case 0:
                    Colorblind.Type = 0;
                    break;
                case 1:
                    Colorblind.Type = 1;
                    break;
                case 2:
                    Colorblind.Type = 2;
                    break;
                case 3:
                    Colorblind.Type = 3;
                    break;
                default:
                    break;
            }*/
    }

    void OnMouseExit() 
    {
        rend.SetActive(false);
        Debug.Log("SpriteRenderer disabled.");
    }

    public enum Botao
    {
        Deuteranopia,
        Protanopia,
        Tritanopia,
        SemFiltro
    }
}