using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CifraLogic : MonoBehaviour
{
    [SerializeField] private EditorCentral editorCentral;
    [SerializeField] private Transform charTemplate;
    
    [SerializeField] private Sprite[] alfabetoNormal;
    [SerializeField] private Sprite[] cifra1;
    [SerializeField] private Sprite[] cifra2;
    [SerializeField] private Sprite[] cifra3;
    [SerializeField] private Sprite[] cifra4;
    [SerializeField] private Sprite[] cifra5;


    private void Start()
    {
        editorCentral.OnNewMessage += (_, e) => DisplayMessage(e.Message, e.Mode);
        editorCentral.OnRemoveMessage += (_, _) =>
        {
            while (transform.childCount > 1) // >1 pra deixar o template lá
            {
                DestroyImmediate(transform.GetChild(1).gameObject);
            }
        };
    }

    /* mode:
     0 - alfabeto normal
     1 - cifra1
     2 - cifra2
     ...
     */
    private void DisplayMessage(string text, int mode)
    {
        switch (mode)
        {
            case 0:
                Display(alfabetoNormal);
                break;
            case 1:
                Display(cifra1);
                break;
            case 2:
                Display(cifra2);
                break;
            case 3:
                Display(cifra3);
                break;
            case 4:
                Display(cifra4);
                break;
            case 5:
                Display(cifra5);
                break;
        }

        return;

        void Display(Sprite[] spriteArr)
        {
            foreach (char c in text.ToLower())
            {
                string ch = c switch
                {
                    ' ' or '\n' => "_",
                    ':' => "(2 pontos)",
                    '?' => "(interrogacao)",
                    '"' => "'",
                    _ => c.ToString()
                };

                Sprite sprite = "abcdefghijklmnopqrstuvwxyzçáãâàéêíóõôú_".Contains(ch)
                    ? spriteArr.FirstOrDefault(spr => spr.name == ch)
                    : alfabetoNormal.FirstOrDefault(spr => spr.name == ch);
                
                if (sprite is null) continue;

                Transform charTransform = Instantiate(charTemplate, transform);
                charTransform.GetComponent<Image>().sprite = sprite;
                charTransform.gameObject.SetActive(true);
            }
        }
    }
}
