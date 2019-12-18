using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassroomSceneChanger : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> screenList; //Lista de scenes, adicionadas manualmente e em ordem
    private int currentScreen = 0; //Número da scene atual, de acordo com a Lista acima.

    public void NextScreen()
    {
        if (currentScreen + 1 < screenList.Capacity)
        {
            screenList[currentScreen].SetActive(false);
            currentScreen++;
            screenList[currentScreen].SetActive(true);
        }
    }

    public void BackScreen()
    {
        if (currentScreen - 1 < 0)
        {
            screenList[currentScreen].SetActive(false);
            currentScreen--;
            screenList[currentScreen].SetActive(true);
        }
    }
}
