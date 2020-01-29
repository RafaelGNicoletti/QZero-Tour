using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public static MapController instance;

    /// <summary>
    /// Armazena a velocidade original do player
    /// </summary>
    private float playerSpeed;
    /// <summary>
    /// Armazena a referencia do player, para facilitar utilização
    /// </summary>
    [SerializeField] private GameObject player;
    /// <summary>
    /// Referencia do canvas da scene
    /// </summary>
    public GameObject canvas;
    /// <summary>
    /// Referencia da câmera da scene
    /// </summary>
    public GameObject camera;
    /// <summary>
    /// Lista de prefabs dos avatares (ordem é importante)
    /// </summary>
    public GameObject[] avatar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // Ativa o avatar escolhido e o marca como target que a camera deve seguir
        avatar[GameManager.instance.GetAvatarSelectedIndex()].SetActive(true);
        camera.GetComponent<BasicCameraFollow>().followTarget = avatar[GameManager.instance.GetAvatarSelectedIndex()].transform;
    }

    private void Start()
    {
        // Salva a referencia do player
        player = GameObject.FindGameObjectWithTag("Player");

        // Se o tutorial não foi visto, mostra e marca como visto
        if (!GameManager.instance.tutorialViewed)
        {
            ClearSpeed();
            GameObject.Find("Canvas").GetComponent<Animator>().SetBool("FirstTime", true);
            GameManager.instance.tutorialViewed = true;

            // Salva a posição do player e da câmera
            GameManager.instance.SetPlayerPos(player.transform.position);
            GameManager.instance.SetCameraPos(camera.transform.position);
        }
        else
        {
            GameObject.Find("Canvas").GetComponent<Animator>().SetBool("Tutorial", false);

            // Coloca o player e a câmera na posição salva
            player.transform.position = GameManager.instance.GetPlayerPos();
            camera.transform.position = GameManager.instance.GetCameraPos();
        }
    }

    /// <summary>
    /// Função que zera a velocidade do player
    /// </summary>
    public void ClearSpeed()
    {
        // Se a velocidade não estiver zerada, salva a velocidade original e zera
        if (player.GetComponent<PlayerMovement>().movementSpeed != 0)
        {
            playerSpeed = player.GetComponent<PlayerMovement>().movementSpeed;
            player.GetComponent<PlayerMovement>().movementSpeed = 0;
        }
    }

    /// <summary>
    /// Fução que restaura a velocidade original do player
    /// </summary>
    public void RestoreSpeed()
    {
        player.GetComponent<PlayerMovement>().movementSpeed = playerSpeed;
    }

    /// <summary>
    /// Função que inverte o target.active
    /// </summary>
    /// <param name="target"></param>
    public void Toggle(GameObject target)
    {
        target.SetActive(!target.active);
    }

    /// <summary>
    /// Função que ativa o trigger do animator do canvas
    /// </summary>
    /// <param name="trigger"></param>
    public void SetAnimationTrigger(string trigger)
    {
        canvas.GetComponent<Animator>().SetTrigger(trigger);
    }

    /// <summary>
    /// Função que marca como true o boolName do animator do canvas
    /// </summary>
    /// <param name="boolName"></param>
    public void SetBoolTrue(string boolName)
    {
        canvas.GetComponent<Animator>().SetBool(boolName, true);
    }

    /// <summary>
    /// Função que marca como false o boolName do animator do canvas
    /// </summary>
    /// <param name="boolName"></param>
    public void SetBoolFalse(string boolName)
    {
        canvas.GetComponent<Animator>().SetBool(boolName, false);
    }

    /// <summary>
    /// Função que abre a tela do elevador
    /// </summary>
    /// <param name="tela"></param>
    public void OpenElevador(GameObject tela)
    {
        MapController.instance.ClearSpeed();
        tela.SetActive(true);
    }

    /// <summary>
    /// Função que fecha a tela do elevador
    /// </summary>
    /// <param name="tela"></param>
    public void CloseElevador(GameObject tela)
    {
        MapController.instance.RestoreSpeed();
        tela.SetActive(false);
    }

    /// <summary>
    /// Função que abre a scene do glossário
    /// </summary>
    /// <param name="sceneName"></param>
    public void OpenGlossary(string sceneName)
    {
        GameManager.instance.SetPlayerPos(player.transform.position);
        GameManager.instance.SetCameraPos(camera.transform.position);
        GameManager.instance.SetLastSceneName(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
