using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject npcTalking = null; //Personagem com o qual o jogador está interagindo
    public PlayerController playerController; //Controlador geral do jogador, refêrencia para poder alterar o estado dele
    public TalkTextBox talkTextBox; //Script do  balão de fala
    public float keyDelay = 0.1f; //Tempo de espera entre inputs consectivos (1f = 1 segundo), serve para evitar múltiplos inputs
    private float timePassed = 0; //Tempo que passou desde o último input

    private void FixedUpdate()
    {
        timePassed += Time.deltaTime; //Adiciona ao tempo que passou desde o último input
    }

    /// <summary>
    /// Recomeça o contador de tempo entre inputs
    /// </summary>
    public void ReseTime()
    {
        timePassed = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC_Talk")) //Se o jogador entrou no trigger de algum NPC que fala, ele recebe a referência a esse NPC
        {
            npcTalking = other.gameObject;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(npcTalking.tag)) //Se o jogador sair da trigger de algum NPC que fala, ele perde a referência ao NPC.
        {
            npcTalking = null;
        }
    }

    /// <summary>
    /// Função que verifica se iniciar a interação com alguma coisa
    /// </summary>
    public void GetInputInteract()
    {
        if(Input.GetKeyDown(KeyCode.Space) && npcTalking && timePassed >= keyDelay)
        {
            npcTalking.GetComponent<NPCTalk>().Talk();
            playerController.SetStatus("talking");
            ReseTime();
        }
    }

    /// <summary>
    /// Função que avança os textos quando se está interagindo com um NPC (conversa)
    /// </summary>
    public void GetInputTalking()
    {
        if (Input.GetKeyDown(KeyCode.Space) && timePassed >= keyDelay)
        {
            talkTextBox.NextText();
            ReseTime();
        }
    }

    /// <summary>
    /// Retorna para o playerController ao status "walking"
    /// </summary>
    public void StopTalking()
    {
        playerController.SetStatus("walking");
    }

}
