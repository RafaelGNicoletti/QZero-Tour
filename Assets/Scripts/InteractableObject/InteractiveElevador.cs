using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveElevador : MonoBehaviour, InteractiveObject
{
    [SerializeField] private GameObject elevatorWindow;

    public void Interact()
    {
        MapController.instance.OpenElevador(elevatorWindow);
        if (GameObject.FindGameObjectWithTag("PopUpBalloon"))
        {
            GameObject.FindGameObjectWithTag("PopUpBalloon").SetActive(false);
        }
    }

    public void CancelGame()
    {

    }

    public void GoToGame()
    {

    }
}
