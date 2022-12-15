using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpoonDragger : MonoBehaviour
{
    private Vector3 _initSpoonPos;
    private Vector3 _mouseOffset = Vector3.zero;

    private void Start()
    {
        _initSpoonPos = this.transform.localPosition;
    }

    private void OnMouseDown()
    {
        _mouseOffset = this.transform.position - Input.mousePosition;
        Cursor.visible = false;
    }

    private void OnMouseDrag()
    {
        // move spoon to mouse
        Vector3 mousePos = Input.mousePosition;
        this.transform.localPosition = mousePos + _mouseOffset;
    }

    private void OnMouseUp()
    {
        // reset spoon position
        this.transform.localPosition = _initSpoonPos;
        Cursor.visible = true;
    }
}
