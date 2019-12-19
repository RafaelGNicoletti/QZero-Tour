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

    /// <summary>
    /// Posição que o jogador deve ser colocado quando ocorre a mudança de scene
    /// </summary>
    [SerializeField] private Vector3 playerInstantiatePos = new Vector3();

    private int avatatarSelected = 0;
    private string playerName = "";

    private Dictionary<string, bool> JogoEntidadeFlags = new Dictionary<string, bool>();

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

    #region Set/Get
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
    
    public void SetPlayerInstantiatePos(Vector3 value)
    {
        playerInstantiatePos = value;
    }

    public Vector3 GetPlayerInstantiatePos()
    {
        return playerInstantiatePos;
    }

    public void AddDataToJogoEntidadeDictionary(string key, bool value)
    {
        if (!JogoEntidadeFlags.ContainsKey(key))
        {
            JogoEntidadeFlags.Add(key, value);
        }

        Debug.Log("Adicionado");
    }

    public void SetDataToJogoEntidadeDictionary(string key, bool value)
    {
        if (JogoEntidadeFlags.ContainsKey(key))
        {
            JogoEntidadeFlags[key] = value;
        }

        Debug.Log("Setou");
    }

    public bool GetDataToJogoEntidadeDictionary(string key)
    {
        //Debug.Log("key: " + key + " - value: " + JogoEntidadeFlags[key]);
        
        return JogoEntidadeFlags[key];
    }

    #endregion

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
