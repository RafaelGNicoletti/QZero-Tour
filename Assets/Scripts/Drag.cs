using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script que inicia
/// </summary>

public abstract class Drag : MonoBehaviour
{
    private float distance = 10;

    public virtual void OnMouseDown()
    {
        OnMouseDrag();
    }


    public virtual void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    public abstract void OnMouseUp();
}
