using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlador da exibição das informações do elevador
/// </summary>
public class ElevadorInfoManager : MonoBehaviour
{
    /// <summary>
    /// Função que mostra a informação no gameObject
    /// </summary>
    /// <param name="gameObject"></param>
    public void ShowInfo(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Função que omite todas as outras informações exibidas
    /// </summary>
    public void HideInfo()
    {
        GameObject[] infos = GameObject.FindGameObjectsWithTag("InfoTextWindow");

        foreach (GameObject info in infos)
        {
            info.SetActive(false);
        }
    }
}
