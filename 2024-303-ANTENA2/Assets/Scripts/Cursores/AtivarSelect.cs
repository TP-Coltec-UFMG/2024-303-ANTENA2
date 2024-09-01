using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarSelect : MonoBehaviour
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
            if (Input.GetMouseButtonDown(0))
            {
                CursorController.instance.ActivateCursorSelectTap();
            }
            if (Input.GetMouseButtonUp(0))
            {
                CursorController.instance.ActivateCursorSelect();
            }
        }
    }

    private void OnMouseEnter()
    {
        CursorController.instance.ActivateCursorSelect();
        estaSobre = true;
    }

    private void OnMouseExit()
    {
        CursorController.instance.ActivateCursorDefault();
        estaSobre = false;
    }
}
