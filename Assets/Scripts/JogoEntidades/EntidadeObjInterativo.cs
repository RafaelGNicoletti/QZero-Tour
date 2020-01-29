using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntidadeObjInterativo : Drag
{
    [Tooltip ("Nome da entidade a qual o logo pertence")]
    public string nome; //Nome da entidade a qual o logo pertence
    public string objectTag; //Tag que o objeto irá procurar (EncaixeLogo, para logos, EncaixeNome, para nomes)
    public GameObject targetSpace; //Referência ao espaço que o objeto está interagindo.
    private Vector3 originPoint; //Ponto em que o objeto é instânciado pela primeira vez
    private Vector3 respawnPoint; //Ponto para qual o objeto irá voltar, caso seja pedido isso
    private bool moveable = true; //Booleano que indica se é possível mover o objeto (verificado em OnMouseDown() e OnMouseDrag()

    public void Start()
    {
        SetOriginPoint(transform.position);
        SetRespawnPoint(transform.position);
        BackToPosition();
        //Caso o objeto tenha um filho que seja elemento de texto (no caso do nome), 
        //ele atualiza para que o que está sendo mostrado ingame bata com o nome.
        if (gameObject.GetComponentInChildren<UnityEngine.UI.Text>() != null)
        {
            gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = nome;
        }
    }

    ///Tanto OnMouseDown() quanto o OnMouseDrag() são implementações dos scripts que estão em Drag, mas
    ///dessa vez eles precisam do booleano moveable.
    ///

    public override void OnMouseDown()
    {
        if (moveable)
        {
            //Debug.Log("Entrou");
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
        if (targetSpace != null) //Se o objeto está para ser colocado em algum lugar
        {
            targetSpace.GetComponent<EntidadeEncaixe>().PutObjectInside(gameObject); //Coloca ele dentro desse lugar.
        }

        BackToPosition(); //O respawn point é alterado caso ele seja colocado em algum lugar, caso ele não tenha sido colocado, volta para o ponto inicial.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(objectTag))
        {
            targetSpace = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == targetSpace)
        {
            targetSpace = null;
        }
    }

    /// <summary>
    /// Define o ponto de origem.
    /// </summary>
    /// <param name="position"></param>
    private void SetOriginPoint(Vector3 position)
    {
        originPoint = position;
    }

    /// <summary>
    /// Define o ponto de respawn.
    /// </summary>
    /// <param name="position"></param>
    public void SetRespawnPoint(Vector3 position)
    {
        respawnPoint = position;
    }

    /// <summary>
    /// Reinicia o ponto de respawn para o ponto de origem.
    /// </summary>
    public void ResetRespawnPoint()
    {
        SetRespawnPoint(originPoint);
    }

    /// <summary>
    /// Volta para a posição de respawn
    /// </summary>
    public void BackToPosition()
    {
        transform.position = respawnPoint;
    }

    /// <summary>
    /// Permite que o objeto seja "mexível" ou não.
    /// </summary>
    /// <param name="b"></param>
    public void SetInteractable(bool b)
    {
        moveable = b;
    }

}
