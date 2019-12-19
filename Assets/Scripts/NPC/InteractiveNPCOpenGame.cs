using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveNPCOpenGame : MonoBehaviour, InteractiveObject
{
    [SerializeField] private string gameSceneName;

    public void Interact()
    {
        GoToGame();
    }

    private void GoToGame()
    {
        GameManager.instance.SetPlayerPos(GameObject.FindGameObjectWithTag("Player").transform.position);
        GameManager.instance.SetCameraPos(GameObject.FindGameObjectWithTag("MainCamera").transform.position);
        GameManager.instance.SetLastSceneName(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

        UnityEngine.SceneManagement.SceneManager.LoadScene(gameSceneName);
    }
}
