using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script principal de controle do personagem principal. Entende os inputs que são dados de acordo com o status atual e os repassa para os outros scripts
/// </summary>
public class PlayerController : MonoBehaviour
{
    private enum Status { walking, talking, menu } //Variavel de estado, que pode assumir os valores que estão dentro de chaves
    [SerializeField]
    private Status currentStatus = Status.walking; //Estado atual do jogador
    public PlayerInteract playerInteract; //Script que realizar as ações quando o jogador está interagindo com algum objeto
    public PlayerMovement playerMovement; //Script que cuida da movimentação do jogador

    /// <summary>
    /// Atualiza o estado atual do jogador
    /// </summary>
    /// <param name="status"></param>
    public void SetStatus(string status)
    {
        if (status.Equals("walking"))
        {
            currentStatus = Status.walking;
        }
        else if (status.Equals("talking"))
        {
            currentStatus = Status.talking;
        }
        else if (status.Equals("menu"))
        {
            currentStatus = Status.menu;
        }
        else
        {
            Debug.LogError("Status não reconhecido no SetStatus");
        }
    }

    /// <summary>
    /// Retorna o estado atual do jogador, em forma de uma string
    /// </summary>
    /// <returns></returns>
    public string GetCurrentStatus()
    {
        if (currentStatus == Status.talking)
        {
            return "talking";
        }
        else if (currentStatus == Status.walking)
        {
            return "walking";
        }
        else if (currentStatus == Status.menu)
        {
            return "menu";
        }
        else
        {
            return "nothing";
        }
    }

    private void Update()
    {
        switch (currentStatus) //Verifica qual dos estados é o atual e aplica as funções de verificar o input
        {
            case Status.walking:
                playerInteract.GetInputInteract();
                playerMovement.GetInputMovement();
                break;

            case Status.talking:
                playerInteract.GetInputTalking();
                break;

            case Status.menu:
                playerInteract.GetInputMenu();
                break;

            default:
                break;
        }
    }
}
