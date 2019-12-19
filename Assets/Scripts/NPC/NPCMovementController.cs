using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementController : MonoBehaviour
{
    // Dicionário que contém as possíveis palavras de direções que podem ser usadas como entrada
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

    #region Variáveis controladoras de IDLE
    [Tooltip("Direções aceitas: cima (ou N), baixo (ou S), esquerda (ou esq, ou O), direita (ou dir, ou L)")]
    public string idleDirection;

    /// Direções a partir do norte, sentido antihorário
    // 8 Posições
    private string[] directions8 = { "N", "NO", "O", "SO", "S", "SL", "L", "NL" };
    // 4 Posições
    private string[] directions4 = { "N", "O", "S", "L" };
    public bool direction8 = false;
    #endregion

    #region Variáveis controladoras de movimento
    public Vector3[] movePositions;
    public float moveSpeed = 5;
    public bool closedMovement = false;
    private int movePositionIndex = 0;
    private int openMovementDirection = 1;
    private Vector3 direction = new Vector3();
    private string[] runDirections8 = { "N", "NO", "O", "SO", "S", "SL", "L", "NL" };
    private string[] runDirections4 = { "N", "O", "S", "L" };
    #endregion

    [SerializeField]
    private Animator animatorNPC;
    [SerializeField]
    private Transform body;

    private bool isTalking = false;

    public void SetIsTalking(bool value)
    {
        isTalking = value;
    }

    void Start()
    {        
        if (isWalking)
        {
            // Código para movimentar o NPC se ele estiver andando - FUTURO
            direction = movePositions[movePositionIndex] - this.transform.position;
            direction.Normalize();

            WalkToAnimation(direction);
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

    private void Update()
    {
        if (isWalking && !isTalking)
        {
            // Movimentação do NPC acontecerá aqui
            // Verifica se o NPC chegou em uma das posições definidas de movimentação
            if ((this.transform.position - (movePositions[movePositionIndex])).magnitude < 0.1)
            {
                if (closedMovement)
                {
                    if (movePositionIndex == movePositions.Length - 1)
                    {
                        movePositionIndex = 0;
                    }
                    else
                    {
                        movePositionIndex++;
                    }
                }
                else
                {
                    if (movePositionIndex == movePositions.Length - 1 && openMovementDirection > 0)
                    {
                        openMovementDirection = -1;
                    }
                    else if (movePositionIndex == 0 && openMovementDirection < 0)
                    {
                        openMovementDirection = 1;
                    }

                    movePositionIndex += openMovementDirection;
                }
            }
            direction = movePositions[movePositionIndex] - this.transform.position;
            direction.Normalize();

            WalkToAnimation(direction);

            //animatorNPC.Play("");
            body.position += (direction * moveSpeed);
        }
    }

    /// <summary>
    /// Função que faz o NPC olhar para o player
    /// </summary>
    /// <param name="playerPos"></param>
    public void LookToPlayer(Transform playerPos)
    {
        isTalking = true;

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

    public void WalkToAnimation(Vector3 direction)
    {
        float angle = Vector3.SignedAngle(Vector3.up, direction, Vector3.forward);

        float sides;
        string[] directions;

        if (direction8)
        {
            sides = runDirections8.Length;
            directions = runDirections8;
        }
        else
        {
            sides = runDirections4.Length;
            directions = runDirections4;
        }

        float step = 360 / sides;

        angle += step / 2;

        if (angle < 0)
        {
            angle += 360;
        }

        int index = Mathf.FloorToInt(angle / step);

        animatorNPC.Play("Run_" + directions[index]);
    }
}
