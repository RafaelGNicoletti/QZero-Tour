using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntidadeEncaixe : MonoBehaviour
{
    public string objectTag;
    public string id = "-1";
    public GameObject insideObject = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(objectTag) && id == "-1")
        {  
            SetObjectInside(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(objectTag) && id.Equals(collision.gameObject.GetComponent<EntidadeObjInterativo>().nome))
        {
            SetObjectOutside(collision.gameObject);
        }
    }

    private void SetObjectInside(GameObject gameObject)
    {
        insideObject = gameObject;
        gameObject.GetComponent<EntidadeObjInterativo>().SetRespawnPoint(transform.position);
        id = gameObject.GetComponent<EntidadeObjInterativo>().nome;
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
            Debug.Log("Lockou");
            insideObject.GetComponent<EntidadeObjInterativo>().SetInteractable(false);
        }
    }
}
