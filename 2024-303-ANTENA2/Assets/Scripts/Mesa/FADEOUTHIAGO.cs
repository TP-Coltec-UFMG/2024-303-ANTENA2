using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FADEOUTHIAGO : MonoBehaviour
{
    [SerializeField] private Image image;
    public bool Terminou { get; private set; }

    private void Start()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float curA = image.color.a;
        float finalA = 1f;
        const float duration = 1.5f;
        float elapsed = 0f;
        Color color = image.color;
        while (elapsed < duration)
        {
            float newA = Mathf.Lerp(curA, finalA, elapsed / duration);
            image.color = new Color(color.r, color.g, color.b, newA);
            elapsed += Time.deltaTime;
            yield return null;
        }

        image.color = new Color(color.r, color.g, color.b, finalA);
        Terminou = true;
    }
    
    /*
    private IEnumerator MoveTelinha(float change)
    {
        float curXPos = telinha.position.x;
        float finalXPos = curXPos + change;
        const float duration = .5f;
        float elapsed = 0f;
        Vector3 pos = telinha.position;
        while (elapsed < duration)
        {
            pos = telinha.position;
            float newX = Mathf.Lerp(curXPos, finalXPos, elapsed / duration);
            pos.x = newX;
            telinha.position = pos;
            elapsed += Time.deltaTime;
            yield return null;
        }

        pos.x = finalXPos;
        telinha.position = pos;
    }*/
}
