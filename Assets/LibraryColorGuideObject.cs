using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Complementa o script LibraryColorGuindeInteract, juntos cuidam do comportamento do guia de cores da biblioteca
/// </summary>
public class LibraryColorGuideObject : MonoBehaviour
{
    PlayerInteract playerInteract;
    public void Start()
    {
        playerInteract = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteract>();
    }
    public void CloseGuide()
    {
        playerInteract.ReseTime();
        gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().SetStatus("walking");
    }

    private void Update()
    {   
        if (playerInteract.InputReady())
        {
            CloseGuide();
        }
    }
}
