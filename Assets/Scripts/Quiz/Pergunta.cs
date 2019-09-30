using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que armazena uma pergunta, as alterantivas de resposta e o índice da resposta correta
/// </summary>
[System.Serializable]
public class Pergunta
{
    [SerializeField] private string theme;
    [SerializeField] private string question;
    [SerializeField] private string[] alternative;
    [SerializeField] private int correctAnswer;

    public Pergunta(int i)
    {
        alternative = new string[i];
    }

    /// <summary>
    /// Função que verifica se ovalor passado corresponde a resposta correta
    /// </summary>
    /// <param name="sel"></param>
    /// <returns></returns>
    public bool VerifyAnswer(int sel)
    {
        if (sel == correctAnswer)
        {
            return true;
        }
        else return false;
    }

    #region Set/Get das variáveis
    public string GetQuestion()
    {
        return question;
    }

    public void SetQuestion(string value)
    {
        question = value;
    }

    /// <summary>
    /// Retorna a alternativa correspondente ao índice passado
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public string GetAlternative(int index)
    {
        return alternative[index];
    }

    /// <summary>
    /// Sobreescreve a alternativa em index pela passada em value
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    public void SetAlternative(int index, string value)
    {
        alternative[index] = value;
    }

    /// <summary>
    /// Retorna o número total de alternativas
    /// </summary>
    /// <returns></returns>
    public int GetNumberOfAlternatives()
    {
        return alternative.Length;
    }

    public void SetCorrectAnswer(int value)
    {
        correctAnswer = value;
    }

    public int GetCorrectAnswer()
    {
        return correctAnswer;
    }
    #endregion

    public void OverrideQuestion(Pergunta newQuestion)
    {
        correctAnswer = newQuestion.GetCorrectAnswer();
        for (int i = 0; i < alternative.Length; i++)
        {
            alternative[i] = newQuestion.GetAlternative(i);
        }
    }
}