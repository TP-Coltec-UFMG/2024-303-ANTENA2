using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CifrasMesa : MouseInteractive
{
    private Vector3 _initialPos;
    private Vector3 _initialITHpos;
    private bool _isCoroutinePlaying;


    private new void Start()
    {
        base.Start();

        _initialPos = transform.position;
        _initialITHpos = imgToHighlight.transform.position;
    }
    
    private void Update()
    {
        const float upAmount = .035f;

        if (MouseOver() && !_isCoroutinePlaying)
        {
            StartCoroutine(MoveVerticalSmooth(_initialPos.y + upAmount));
        }
        else if (!MouseOver() && !_isCoroutinePlaying)
        {
            StartCoroutine(MoveVerticalSmooth(_initialPos.y));
        }

        imgToHighlight.transform.position = _initialITHpos;
    }
    
    private IEnumerator MoveVerticalSmooth(float finalYPos)
    {
        _isCoroutinePlaying = true;
        
        float curYPos = transform.position.y;
        const float duration = .1f;
        float elapsed = 0f;
        Vector3 pos = transform.position;
        while (elapsed < duration)
        {
            pos = transform.position;
            float newY = Mathf.Lerp(curYPos, finalYPos, elapsed / duration);
            pos.y = newY;
            transform.position = pos;
            elapsed += Time.deltaTime;
            yield return null;
        }

        _isCoroutinePlaying = false;
        pos.y = finalYPos;
        transform.position = pos;
    }

}
