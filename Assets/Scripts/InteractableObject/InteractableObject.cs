using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{
    public string sceneName;
    private GameObject player;
    private GameObject camera;

    public void LoadMinigame()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.Find("Main Camera");
        GameManager.instance.SetPlayerPos(player.transform.position);
        GameManager.instance.SetCameraPos(camera.transform.position);

        SceneManager.LoadScene(sceneName);
    }
}
