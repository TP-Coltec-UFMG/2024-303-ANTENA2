using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CifrasMesa : MouseInteractive
{
    private Vector3 _initialPos;
    private Vector3 _initialITHpos;


    private new void Start()
    {
        base.Start();

        _initialPos = transform.position;
        _initialITHpos = imgToHighlight.transform.position;
    }
    
    private void Update()
    {
        const float upAmount = .03f;

        Vector3 pos = transform.position;
        if (MouseOver())
        {
            pos.y = _initialPos.y + upAmount;
        }
        else
        {
            pos = _initialPos;
        }

        transform.position = pos;
        imgToHighlight.transform.position = _initialITHpos;
    }
}
