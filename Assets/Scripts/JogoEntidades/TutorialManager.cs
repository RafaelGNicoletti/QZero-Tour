using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public void TurnOn(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void TurnOff(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
