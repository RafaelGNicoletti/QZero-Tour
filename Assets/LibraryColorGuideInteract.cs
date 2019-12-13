using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Complementa o script LibraryColorGuindeObject, juntos cuidam do comportamento do guia de cores da biblioteca
/// </summary>
public class LibraryColorGuideInteract : MonoBehaviour, InteractiveObject
{
    [SerializeField]
    private GameObject colorGuide;
    public void Interact()
    {
        if (!colorGuide.activeSelf)
        {
            OpenGuide();
        }
    }

    private void OpenGuide()
    {
        colorGuide.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().SetStatus("menu");
    }
}
