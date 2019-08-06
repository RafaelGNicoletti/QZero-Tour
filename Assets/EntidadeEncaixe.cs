using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntidadeEncaixe : MonoBehaviour
{
    public string objectTag;
    public string id = "-1";
    public GameObject insideObject = null;
    private bool locked = false;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(objectTag) && id.Equals(collision.gameObject.GetComponent<EntidadeObjInterativo>().nome))
        {
            SetObjectOutside(collision.gameObject);
        }
    }

    public void PutObjectInside(GameObject gameObject)
    {
        bool correctTag = gameObject.CompareTag(objectTag);
        if (!locked)
        {
            if (correctTag && id == "-1")
            {
                SetObjectInside(gameObject);
            }
            else if (correctTag)
            {
                Debug.Log("Entrou aqui");
                GetOutObject(insideObject);
                SetObjectInside(gameObject);
            }
        }
    }

    private void SetObjectInside(GameObject gameObject)
    {
        insideObject = gameObject;
        gameObject.GetComponent<EntidadeObjInterativo>().SetRespawnPoint(transform.position);
        id = gameObject.GetComponent<EntidadeObjInterativo>().nome;
    }

    private void GetOutObject(GameObject gameObject)
    {
        SetObjectOutside(gameObject);
        gameObject.GetComponent<EntidadeObjInterativo>().BackToPosition();
    }

    private void SetObjectOutside(GameObject gameObject)
    {
        insideObject = null;
        gameObject.GetComponent<EntidadeObjInterativo>().ResetRespawnPoint();
        id = "-1";
    }

    public void LockObject()
    {
        if (insideObject != null)
        {
            insideObject.GetComponent<EntidadeObjInterativo>().SetInteractable(false);
            locked = true;
        }
    }
}
