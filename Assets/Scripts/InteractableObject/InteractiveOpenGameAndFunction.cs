using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveOpenGameAndFunction : MonoBehaviour, InteractiveObject
{
    [SerializeField] private string gameSceneName;
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
    }

    public void CancelGame()
    {
        MapController.instance.RestoreSpeed();

        altDialog.SetActive(false);
    }

    public void GoToGame()
    {
        GameManager.instance.SetPlayerPos(GameObject.FindGameObjectWithTag("Player").transform.position);
        GameManager.instance.SetCameraPos(GameObject.FindGameObjectWithTag("MainCamera").transform.position);
        GameManager.instance.SetLastSceneName(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

        UnityEngine.SceneManagement.SceneManager.LoadScene(gameSceneName);
    }
}
