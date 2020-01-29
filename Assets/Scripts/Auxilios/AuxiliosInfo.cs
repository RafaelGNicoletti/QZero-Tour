using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe base para a lista de auxilios
/// </summary>
[System.Serializable]
public class AuxiliosInfo
{
    // Pergunta a ser mostrada
    [SerializeField] private string pergunta;
    // Texto da resposta afirmativa
    [SerializeField] private string textoSim;
    // Texto da resposta negativa
    [SerializeField] private string textoNao;
    // índice da proxima pergunta a ser exibida caso resposta positiva
    [SerializeField] private int proxPerguntaSim;
    // índice da proxima pergunta a ser exibida caso resposta negativa
    [SerializeField] private int proxPerguntaNao;
    
    /// <summary>
    /// Função de ajuste de índices das perguntas
    /// </summary>
    public void Adjust()
    {
        proxPerguntaNao--;
        proxPerguntaSim--;
    }

    /// <summary>
    /// Retorna o texto de pergunta
    /// </summary>
    /// <returns></returns>
    public string GetPergunta()
    {
        return pergunta;
    }

    /// <summary>
    /// Retorna o texto de resposta afirmativa
    /// </summary>
    /// <returns></returns>
    public string GetTextoSim()
    {
        return textoSim;
    }

    /// <summary>
    /// Retorna o texto de resposta negativa
    /// </summary>
    /// <returns></returns>
    public string GetTextoNao()
    {
        return textoNao;
    }

    /// <summary>
    /// Retorna o índice da proxima pergunta caso a resposta seja afirmativa
    /// </summary>
    /// <returns></returns>
    public int GetProxPerguntaSim()
    {
        return proxPerguntaSim;
    }

    /// <summary>
    /// Retorna o índice da proxima pergunta caso a resposta seja negativa
    /// </summary>
    /// <returns></returns>
    public int GetProxPerguntaNao()
    {
        return proxPerguntaNao;
    }
}
