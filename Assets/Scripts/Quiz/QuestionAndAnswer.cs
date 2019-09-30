using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que armazena as informações de uma pergunta realizada
/// </summary>
[System.Serializable]
public class QuestionAndAnswer
{
    [SerializeField] private string time;
    [SerializeField] private int dificultyLevel = -1;
    [SerializeField] private int questionNumber = -1;
    [SerializeField] private int answerSelected = -1;
    [SerializeField] private bool isCorrect = false;

    /// <summary>
    /// Cosntrutor básico
    /// </summary>
    public QuestionAndAnswer() { }

    public override string ToString()
    {
        return time + "," + dificultyLevel + "," + questionNumber + "," + answerSelected + "\n";
    }

    #region Set/Get das variáveis
    public void SetDificultyLevel(int value)
    {
        dificultyLevel = value;
    }

    public int GetDificultyLevel()
    {
        return dificultyLevel;
    }

    public void SetQuestionNumber(int value)
    {
        questionNumber = value;
    }

    public int GetQuestionNumber()
    {
        return questionNumber;
    }

    public void SetAnswerSelected(int value)
    {
        answerSelected = value;
    }

    public int GetAnswerSelected()
    {
        return answerSelected;
    }

    public void SetIsCorrect(bool value)
    {
        isCorrect = value;
    }

    public bool GetIsCorrect()
    {
        return isCorrect;
    }

    public void SetTime()
    {
        time = System.DateTime.Now.ToString("dd/MM/yyyy - hh:mm");
    }

    public string GetTime()
    {
        return time;
    }
    #endregion
}