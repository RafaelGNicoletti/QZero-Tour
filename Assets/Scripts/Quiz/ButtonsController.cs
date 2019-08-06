﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ButtonsController", menuName = "My Assets/Controlador de Botões")]
public class ButtonsController : ScriptableObject
{
    private int selectedButton = -1;

    /// <summary>
    /// Função que verifica automáticamente se a alternativa selecionada é a correta
    /// </summary>
    /// <param name="value"></param>
    public void AnswerSelected(int value)
    {
        QuizManager.instance.CheckAnswer(value);
    }

    public void FadeOutPanel()
    {
        GameObject.Find("StartPanel").GetComponent<Animator>().SetTrigger("FadeOut");
    }

    public void StartQuiz()
    {
        GameObject.Find("QuizManager").GetComponent<QuizManager>().PrepareNewQuestion();
    }

    #region Funções auxiliares
    /// <summary>
    /// Função que desmarca todos os botões da tela
    /// </summary>
    private void UnselectAllButtons()
    {
        UnityEngine.UI.Button[] buttons = GameObject.FindObjectsOfType<UnityEngine.UI.Button>();

        foreach (UnityEngine.UI.Button button in buttons)
        {
            button.interactable = true;
        }
    }

    #endregion
}