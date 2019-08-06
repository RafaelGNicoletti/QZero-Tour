using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que gera um ScriptableObject contendo uma lista de perguntas
/// </summary>
[CreateAssetMenu(fileName = "Perguntas", menuName = "My Assets/Lista de Perguntas")]
public class Perguntas : ScriptableObject
{
    [SerializeField]
    private Pergunta[] quizQuestions;

    #region Set/Get das informações
    /// <summary>
    /// Retorna a pergunta na posição do indice
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Pergunta GetQuestion(int index)
    {
        return quizQuestions[index];
    }

    /// <summary>
    /// Retorna o total de perguntas existentes
    /// </summary>
    /// <returns></returns>
    public int GetLenght()
    {
        return quizQuestions.Length;
    }

    #endregion
}