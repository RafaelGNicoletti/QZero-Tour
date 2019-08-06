using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntidadeObjInterativo : Drag
{
    [Tooltip ("Nome da entidade a qual o logo pertence")]
    public string nome;
    public GameObject currentSpace;
    private Vector3 originPoint;
    private Vector3 respawnPoint;
    private bool moveable = true;

    public override void OnMouseDown()
    {
        if (moveable)
        {
            Debug.Log("Entrou");
            OnMouseDrag();
        }
    }

    public override void OnMouseDrag()
    {
        if (moveable)
        {
            base.OnMouseDrag();
        }
    }

    public override void OnMouseUp()
    {

        BackToPosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Encaixe"))
        {
            currentSpace = collision.gameObject;
        }
    }

    public void Awake()
    {
        SetOriginPoint(transform.position);
        SetRespawnPoint(transform.position);
        BackToPosition();
        if (gameObject.GetComponentInChildren<UnityEngine.UI.Text>() != null)
        {
            gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = nome;
        }
    }

    private void SetOriginPoint(Vector3 position)
    {
        originPoint = position;
    }

    public void SetRespawnPoint(Vector3 position)
    {
        respawnPoint = position;
    }

    public void ResetRespawnPoint()
    {
        SetRespawnPoint(originPoint);
    }


    private void BackToPosition()
    {
        transform.position = respawnPoint;
    }

    public void SetInteractable(bool b)
    {
        moveable = b;
    }

}
