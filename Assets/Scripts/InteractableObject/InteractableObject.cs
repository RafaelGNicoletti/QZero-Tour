using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{
    public string sceneName;
    public Vector3 newScenePlayerPos;

    private GameObject player;
    private GameObject camera;

    [SerializeField] private bool talkTo;
    [SerializeField] private bool enterBuilding;
    [SerializeField] private bool enterGame;

    #region Get/Set
    public bool GetTalkTo()
    {
        return talkTo;
    }

    public bool GetEnterBuilding()
    {
        return enterBuilding;
    }

    public bool GetEnterGame()
    {
        return enterGame;
    }
    #endregion

    public void LoadMinigame()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.Find("Main Camera");
        GameManager.instance.SetPlayerPos(player.transform.position);
        GameManager.instance.SetCameraPos(camera.transform.position);

        SceneManager.LoadScene(sceneName);
    }

    public void LoadMap()
    {
        GameManager.instance.SetPlayerPos(newScenePlayerPos);
        GameManager.instance.SetCameraPos(new Vector3 (newScenePlayerPos.x, newScenePlayerPos.y, newScenePlayerPos.z-10));

        SceneManager.LoadScene(sceneName);
    }
}
