using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementController : MonoBehaviour
{
    private Dictionary<string, string> idleDirectionDictionary = new Dictionary<string, string>
    {
        { "cima", "Idle_N" },
        { "baixo", "Idle_S" },
        { "esquerda", "Idle_O" },
        { "esq", "Idle_O" },
        { "direita", "Idle_L" },
        { "dir", "Idle_L" }
    };

    public bool isWalking;
    [Tooltip("Direções aceitas: cima, baixo, esquerda (ou esq), direita (ou dir)")]
    public string idleDirection;

    [SerializeField]
    private Animator animatorNPC;

    void Start()
    {        
        if (isWalking)
        {
            // Código para movimentar o NPC se ele estiver andando - FUTURO
        }
        else
        {
            // Código para selecionar a direção que o NPC vai estar parado olhando
            if (idleDirectionDictionary.ContainsKey(idleDirection))
            {
                animatorNPC.Play(idleDirectionDictionary[idleDirection]);
            }
            else
            {
                Debug.LogError("Direção não existente no dicionário");
            }
        }
    }
}
