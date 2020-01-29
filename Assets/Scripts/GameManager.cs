using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static GameObject gameManager;

    /// <summary>
    /// Informa se o tutorial já foi visto pelo menos uma vez ou não
    /// </summary>
    public bool tutorialViewed = false;
    /// <summary>
    /// Posição do player na scene, utilizado em mudanças de scenes
    /// </summary>
    [SerializeField] private Vector3 playerPositionOnMap = new Vector3();
    /// <summary>
    /// Posição da câmera na scene, utilizado em mudanças de scenes
    /// </summary>
    [SerializeField] private Vector3 cameraPositionOnMap = new Vector3();

    /// <summary>
    /// Posição que o jogador deve ser colocado quando ocorre a mudança de scene
    /// </summary>
    [SerializeField] private Vector3 playerInstantiatePos = new Vector3();

    /// <summary>
    /// Nome da scene anterior, utilizada para voltar a scene correta
    /// </summary>
    private string lastSceneName;

    /// <summary>
    /// Índice do avatar selecionado
    /// </summary>
    private int avatatarSelected = 0;
    /// <summary>
    /// Nome do jogador
    /// </summary>
    private string playerName = "";

    /// <summary>
    /// Dicionário que contém os flags que indicam qual dos jogos das entidades já foram concluídos
    /// </summary>
    [SerializeField] private Dictionary<string, bool> JogoEntidadeFlags = new Dictionary<string, bool>();
    
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
    /// <summary>
    /// Salva o índice do avatar selecionado
    /// </summary>
    /// <param name="index"></param>
    public void SetAvatarSelectedIndex(int index)
    {
        avatatarSelected = index;
    }

    /// <summary>
    /// Retorna o índice salvo do avatar selecionado
    /// </summary>
    /// <returns></returns>
    public int GetAvatarSelectedIndex()
    {
        return avatatarSelected;
    }

    /// <summary>
    /// Salva o nome do player
    /// </summary>
    /// <param name="name"></param>
    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    /// <summary>
    /// Retorna o nome salvo do player
    /// </summary>
    /// <returns></returns>
    public string GetPlayerName()
    {
        return playerName;
    }

    /// <summary>
    /// Salva a posição do player
    /// </summary>
    /// <param name="newPos"></param>
    public void SetPlayerPos(Vector3 newPos)
    {
        playerPositionOnMap = newPos;
    }

    /// <summary>
    /// Retorna a posição salva do player
    /// </summary>
    /// <returns></returns>
    public Vector3 GetPlayerPos()
    {
        return playerPositionOnMap;
    }

    /// <summary>
    /// Salva a posição da câmera
    /// </summary>
    /// <param name="newPos"></param>
    public void SetCameraPos(Vector3 newPos)
    {
        cameraPositionOnMap = newPos;
    }

    /// <summary>
    /// Retorna a posição salva da câmera
    /// </summary>
    /// <returns></returns>
    public Vector3 GetCameraPos()
    {
        return cameraPositionOnMap;
    }
    
    //public void SetPlayerInstantiatePos(Vector3 value)
    //{
    //    playerInstantiatePos = value;
    //}

    //public Vector3 GetPlayerInstantiatePos()
    //{
    //    return playerInstantiatePos;
    //}

    /// <summary>
    /// Adiciona informação ao dicionário de flags do jogo entidades
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void AddDataToJogoEntidadeDictionary(string key, bool value)
    {
        // Se a key não existe no dicionário, adiciona o par (key, value)
        if (!JogoEntidadeFlags.ContainsKey(key))
        {
            JogoEntidadeFlags.Add(key, value);
        }
    }

    /// <summary>
    /// Altera o value já existente referente a key no dicionário de flags do jogo entidade
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void SetDataToJogoEntidadeDictionary(string key, bool value)
    {
        // Se a key existe no dicionário, altera o value dela
        if (JogoEntidadeFlags.ContainsKey(key))
        {
            JogoEntidadeFlags[key] = value;
        }
    }

    /// <summary>
    /// Retorna uma informação do dicionário do jogo entidade
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool GetDataToJogoEntidadeDictionary(string key)
    {
        return JogoEntidadeFlags[key];
    }

    /// <summary>
    /// Salva o nome da última scene
    /// </summary>
    /// <param name="sceneName"></param>
    public void SetLastSceneName(string sceneName)
    {
        lastSceneName = sceneName;
    }

    /// <summary>
    /// Retorna o nome salvo da última scene
    /// </summary>
    /// <returns></returns>
    public string GetLastSceneName()
    {
        return lastSceneName;
    }

    #endregion

    #region Loader
    /// <summary>
    /// Cria instâncias dos prefabs necessários antes de qualquer coisa
    /// </summary>
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
