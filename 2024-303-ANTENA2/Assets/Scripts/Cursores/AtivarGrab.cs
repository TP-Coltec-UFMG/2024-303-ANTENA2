using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarGrab : MonoBehaviour
{
    private bool estaSobre = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (estaSobre)
        {
            if(Input.GetMouseButtonDown(0))
            {
                CursorController.instance.ActivateCursorGrabbing();
            }
            if (Input.GetMouseButtonUp(0))
            {
                CursorController.instance.ActivateCursorGrab();
            }
        }
    }

    private void OnMouseEnter()
    {
        CursorController.instance.ActivateCursorGrab();
        estaSobre = true;
    }

    private void OnMouseExit()
    {
        CursorController.instance.ActivateCursorDefault();
        estaSobre = false;
    }
}
