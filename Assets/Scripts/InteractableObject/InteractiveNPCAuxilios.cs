using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveNPCAuxilios : MonoBehaviour, InteractiveObject
{
    [SerializeField] private AuxiliosManager auxiliosManager;
    [SerializeField] private GameObject altDialog;
    [SerializeField] private string gameIntro;
    [SerializeField] private string confirmText, cancelText;

    public void Interact()
    {
        MapController.instance.ClearSpeed();

        altDialog.SetActive(true);
        altDialog.GetComponentInChildren<UnityEngine.UI.Text>().text = gameIntro;

        altDialog.transform.GetChild(2).GetComponentInChildren<UnityEngine.UI.Text>().text = confirmText;
        altDialog.transform.GetChild(3).GetComponentInChildren<UnityEngine.UI.Text>().text = cancelText;

        altDialog.transform.GetChild(2).GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
        altDialog.transform.GetChild(3).GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();

        altDialog.transform.GetChild(2).GetComponent<UnityEngine.UI.Button>().onClick.AddListener(GoToGame);
        altDialog.transform.GetChild(3).GetComponent<UnityEngine.UI.Button>().onClick.AddListener(CancelGame);

        altDialog.transform.GetChild(3).GetComponent<UnityEngine.UI.Button>().Select();
    }
    
    public void CancelGame()
    {
        MapController.instance.RestoreSpeed();

        altDialog.SetActive(false);
    }

    public void GoToGame()
    {
        auxiliosManager.StartAuxilioMinigame();

        altDialog.SetActive(false);
    }
}
