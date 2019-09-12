using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBalloon : MonoBehaviour
{
    public GameObject balloon;
    public Vector3 balloonPos;
    private GameObject tempBalloon;

    /// <summary>
    /// Função que instancia um GameObject em uma posição definida por balloonPos
    /// </summary>
    public void CreateBalloon()
    {
        tempBalloon = Instantiate(balloon, this.transform);
        tempBalloon.transform.position += balloonPos;
    }

    /// <summary>
    /// Função que destroi o GameObject instanciado
    /// </summary>
    public void DestroyBalloon()
    {
        Destroy(tempBalloon);
    }
}
