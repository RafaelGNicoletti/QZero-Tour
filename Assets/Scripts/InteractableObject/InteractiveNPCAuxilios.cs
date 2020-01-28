using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveNPCAuxilios : MonoBehaviour, InteractiveObject
{
    [SerializeField] private AuxiliosManager auxiliosManager;

    public void Interact()
    {
        auxiliosManager.StartAuxilioMinigame();
    }
}
