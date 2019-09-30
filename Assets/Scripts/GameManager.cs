using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static GameObject gameManager;

    public bool tutorialViewed = false;
    [SerializeField] private Vector3 playerPositionOnMap = new Vector3();
    [SerializeField] private Vector3 cameraPositionOnMap = new Vector3();

    private int avatatarSelected = -1;
    private string playerName = "";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetAvatarSelectedIndex(int index)
    {
        avatatarSelected = index;
    }

    public int GetAvatarSelectedIndex()
    {
        return avatatarSelected;
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SetPlayerPos(Vector3 newPos)
    {
        playerPositionOnMap = newPos;
    }

    public Vector3 GetPlayerPos()
    {
        return playerPositionOnMap;
    }

    public void SetCameraPos(Vector3 newPos)
    {
        cameraPositionOnMap = newPos;
    }

    public Vector3 GetCameraPos()
    {
        return cameraPositionOnMap;
    }

    #region Loader
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void InitializeManagers()
    {
        gameManager = Resources.Load("Prefabs/Managers/GameManager") as GameObject;

        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }
    }
    #endregion
}
