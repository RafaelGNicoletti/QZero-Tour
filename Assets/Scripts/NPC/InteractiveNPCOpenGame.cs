using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveNPCOpenGame : MonoBehaviour, InteractiveObject
{
    [SerializeField] private string gameSceneName;
    [SerializeField] private GameObject altDialog;
    [SerializeField] private string gameIntro;

    public void Interact()
    {
        altDialog.SetActive(true);
        altDialog.GetComponentInChildren<UnityEngine.UI.Text>().text = gameIntro;
    }

    public void CancelGame()
    {
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
