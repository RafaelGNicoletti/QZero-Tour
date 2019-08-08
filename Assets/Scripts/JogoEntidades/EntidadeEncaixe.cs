using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntidadeEncaixe : MonoBehaviour
{
    public string objectTag; //Tag dos objetos que ele pode receber
    public string id = "-1"; //Nome do objeto que está dentro do encaixe
    private GameObject insideObject = null; //Referência ao objeto que está dentro do encaixe
    private bool locked = false; //É possível trocar o objeto do encaixe?

    private void OnTriggerExit2D(Collider2D collision)
    {
        ///Verifica se o objeto que está saindo do trigger é o objeto que deveria estar dentro dele, antes de ativar a função que retira o objeto.
        if (collision.CompareTag(objectTag) && id.Equals(collision.gameObject.GetComponent<EntidadeObjInterativo>().nome))
        {
            SetObjectOutside(collision.gameObject);
        }
    }

    /// <summary>
    /// Função chamada por outros objetos, verifica se é possível colocar o objeto dentro do encaixe.
    /// </summary>
    /// <param name="gameObject"></param>
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
                GetOutObject(insideObject);
                SetObjectInside(gameObject);
            }
        }
    }

    /// <summary>
    /// Após a verificação, coloca o objeto no encaixe
    /// </summary>
    /// <param name="gameObject"></param>
    private void SetObjectInside(GameObject gameObject)
    {
        insideObject = gameObject;
        gameObject.GetComponent<EntidadeObjInterativo>().SetRespawnPoint(transform.position);
        id = gameObject.GetComponent<EntidadeObjInterativo>().nome;
    }

    /// <summary>
    /// Tira o objeto do encaixe e o manda de volta para sua posição de respawn
    /// </summary>
    /// <param name="gameObject"></param>
    private void GetOutObject(GameObject gameObject)
    {
        SetObjectOutside(gameObject);
        gameObject.GetComponent<EntidadeObjInterativo>().BackToPosition();
    }

    /// <summary>
    /// Retira o objeto do encaixe e reseta o ponto de respawn dele.
    /// </summary>
    /// <param name="gameObject"></param>
    private void SetObjectOutside(GameObject gameObject)
    {
        insideObject = null;
        gameObject.GetComponent<EntidadeObjInterativo>().ResetRespawnPoint();
        id = "-1";
    }

    /// <summary>
    /// Pede para que o objeto não seja mais movível e proíbe a substituição desse objeto.
    /// </summary>
    public void LockObject()
    {
        if (insideObject != null)
        {
            insideObject.GetComponent<EntidadeObjInterativo>().SetInteractable(false);
            locked = true;
        }
    }
}
