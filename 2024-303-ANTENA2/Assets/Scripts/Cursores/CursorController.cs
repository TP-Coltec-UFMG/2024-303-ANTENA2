using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public static CursorController instance;

    public Texture2D cursorDefault, cursorGrab, cursorGrabbing, cursorSelect, cursorSelectTap, cursorUnavailable, cursorReVertical;

    private void Awake()
    {
        instance = this;
        ActivateCursorDefault();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateCursorDefault() { Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto); }

    public void ActivateCursorGrab() { Cursor.SetCursor(cursorGrab, new Vector2(cursorGrab.width / 2, 0), CursorMode.Auto); }

    public void ActivateCursorGrabbing() { Cursor.SetCursor(cursorGrabbing, new Vector2(cursorGrabbing.width / 2, 0), CursorMode.Auto); }

    public void ActivateCursorSelect() { Cursor.SetCursor(cursorSelect, new Vector2(cursorSelect.width / 2, 0), CursorMode.Auto); }

    public void ActivateCursorSelectTap() { Cursor.SetCursor(cursorSelectTap, new Vector2(cursorSelectTap.width / 2, 0), CursorMode.Auto); }

    public void ActivateCursorUnavailable() { Cursor.SetCursor(cursorUnavailable, Vector2.zero, CursorMode.Auto); }
}
