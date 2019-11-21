using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementController : MonoBehaviour
{
    private Dictionary<string, string> idleDirectionDictionary = new Dictionary<string, string>
    {
        { "cima", "Idle_N" },
        { "N", "Idle_N" },
        { "baixo", "Idle_S" },
        { "S", "Idle_S" },
        { "esquerda", "Idle_O" },
        { "esq", "Idle_O" },
        { "O", "Idle_O" },
        { "direita", "Idle_L" },
        { "dir", "Idle_L" },
        { "L", "Idle_L" }
    };

    public bool isWalking;
    [Tooltip("Direções aceitas: cima (ou N), baixo (ou S), esquerda (ou esq, ou O), direita (ou dir, ou L)")]
    public string idleDirection;

    [SerializeField]
    private Animator animatorNPC;

    /// A partir do norte, sentido antihorário
    // 8 Posições
    private string[] directions8 = { "N", "NO", "O", "SO", "S", "SL", "L", "NL" };
    // 4 Posições
    private string[] directions4 = { "N", "O", "S", "L" };

    public bool direction8 = false;

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

    public void LookToPlayer(Transform playerPos)
    {
        Vector2 direction = new Vector2();
        direction = playerPos.position - this.transform.position;
        direction = direction.normalized;
        float angle = Vector2.SignedAngle(Vector2.up, direction);

        float sides;
        string[] directions;

        if (direction8)
        {
            sides = directions8.Length;
            directions = directions8;
        }
        else
        {
            sides = directions4.Length;
            directions = directions4;
        }

        float step = 360 / sides;

        angle += step/2;

        if (angle < 0)
        {
            angle += 360;
        }

        int index = Mathf.FloorToInt(angle/step);

        animatorNPC.Play("Idle_" + directions[index]);
    }
}
