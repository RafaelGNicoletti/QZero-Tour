﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject npcTalking = null; //Personagem com o qual o jogador está interagindo
    public PlayerController playerController; //Controlador geral do jogador, refêrencia para poder alterar o estado dele
    public TalkTextBox talkTextBox; //Script do  balão de fala
    public float keyDelay = 0.1f; //Tempo de espera entre inputs consectivos (1f = 1 segundo), serve para evitar múltiplos inputs
    private float timePassed = 0; //Tempo que passou desde o último input

    public GameObject interactableObj = null;

    [SerializeField]
    private InteractableObject interactableObject;

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
            other.GetComponent<NPCBalloon>().CreateBalloon();
        }
        /// Interação com outros objetos - usado para abrir os minijogos
        /// TEMPORÁRIO
        else if (other.CompareTag("Interactable_Object"))
        {
            interactableObj = other.gameObject;

            interactableObject = interactableObj.GetComponent<InteractableObject>();

            other.GetComponent<NPCBalloon>().CreateBalloon();
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (npcTalking != null && other.CompareTag(npcTalking.tag)) //Se o jogador sair da trigger de algum NPC que fala, ele perde a referência ao NPC.
        {
            npcTalking = null;
            other.GetComponent<NPCBalloon>().DestroyBalloon();
        }
        /// Interação com outros objetos - usado para abrir os minijogos
        /// TEMPORÁRIO
        else if (interactableObj != null && other.CompareTag(interactableObj.tag))
        {
            interactableObj = null;
            other.GetComponent<NPCBalloon>().DestroyBalloon();
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

            // Player olha pra NPC e NPC olha pra player...
            npcTalking.GetComponent<NPCTalk>().LookToPlayer(this.transform);
            LookTo(npcTalking.transform);

            ReseTime();
        }
        /// Interação com outros objetos - usado para abrir os minijogos
        /// TEMPORÁRIO
        else if (Input.GetKeyDown(KeyCode.Space) && interactableObj && timePassed >= keyDelay)
        {
            if (interactableObject.GetEnterGame())
            {
                interactableObject.LoadMinigame();
            }
            else if (interactableObject.GetEnterBuilding())
            {
                interactableObject.LoadMap();
            }
            else if (interactableObject.GetTalkTo())
            {
            }
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
        npcTalking.transform.parent.parent.GetComponentInChildren<NPCMovementController>().SetIsTalking(false);
    }

    /// <summary>
    /// Fun~ção que faz o player olhar para algo (target)
    /// </summary>
    /// <param name="target"></param>
    public void LookTo(Transform target)
    {
        Vector2 direction = new Vector2();
        direction = target.position - this.transform.position;
        direction = direction.normalized;
        //direction /= 100;

        GetComponentInChildren<PlayerCharacterRenderer>().SetDirection(direction);
    }
}
