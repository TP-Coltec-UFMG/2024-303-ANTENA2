using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiraCoiso : MonoBehaviour
{
    [SerializeField] private Image coiso;

    private void Update()
    {
        Quaternion rotation = coiso.transform.rotation;
        
        // Debug.Log(1);
        switch (Colorblind.Type)
        {
            case 0: // Sem
                rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, -45);
                break;
            case 1: // Prot
                rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 135);
                break;
            case 2: // Deut
                rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 45);
                break;
            case 3: // Trit
                rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, -135);
                break;
        }

        coiso.rectTransform.localRotation = rotation;
    }
}
