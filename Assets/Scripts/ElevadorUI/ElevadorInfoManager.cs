using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevadorInfoManager : MonoBehaviour
{
    public void ShowInfo(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void HideInfo()
    {
        GameObject[] infos = GameObject.FindGameObjectsWithTag("InfoTextWindow");

        foreach (GameObject info in infos)
        {
            info.SetActive(false);
        }
    }
}
