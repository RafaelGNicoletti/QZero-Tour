using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager da funcionalidade dos auxilios
/// </summary>
public class AuxiliosManager : MonoBehaviour
{
    // Lista que contem as informações
    public AuxiliosInfoList auxiliosList;
    // Tela da funcionalidade onde as interações serão realizadas
    public GameObject telaAuxilio;

    // Caixa de texto para exibição das perguntas e informações
    public UnityEngine.UI.Text textWindow;
    // Botões de interação
    public GameObject botaoSim, botaoNao, botaoContinuar;

    // Índice da informação que esta sendo exibida/utilizada no momento
    private int questionIndex;
    // Bool que indica se a funcionalidade está rodando ou não
    private bool isRunning = false;

    /// <summary>
    /// Função que prepara e inicia a funcionalidade
    /// </summary>
    public void StartAuxilioMinigame()
    {
        if (!isRunning)
        {
            isRunning = true;

            MapController.instance.ClearSpeed();
            telaAuxilio.SetActive(true);
            ResetAll();

            NextQuestion();
        }
    }

    /// <summary>
    /// Função que mostra o textToShow na janela de texto
    /// </summary>
    /// <param name="textToShow"></param>
    public void ShowText(string textToShow)
    {
        textWindow.text = textToShow;
    }

    /// <summary>
    /// Função que controla o que deve acontecer caso a resposta escolhida seja afirmativa
    /// </summary>
    public void RespostaSim()
    {
        ShowText(auxiliosList.GetInfo(questionIndex).GetTextoSim());
        questionIndex = auxiliosList.GetInfo(questionIndex).GetProxPerguntaSim();
        ApagaBotoesSimNao();
        MostraBotaoContinuar();
    }

    /// <summary>
    /// Função que controla o que deve acontecer caso a resposta escolhida seja negativa
    /// </summary>
    public void RespostaNao()
    {
        ShowText(auxiliosList.GetInfo(questionIndex).GetTextoNao());
        questionIndex = auxiliosList.GetInfo(questionIndex).GetProxPerguntaNao();
        ApagaBotoesSimNao();
        MostraBotaoContinuar();
    }

    /// <summary>
    /// Função que prepara e mostra a proxima informação
    /// </summary>
    public void NextQuestion()
    {
        // Se não é o último elemento da lista, mostra o próximo
        if (questionIndex < auxiliosList.GetSize())
        {
            ApagaBotaoContinuar();

            // Mostra a proxima informação
            ShowText(auxiliosList.GetInfo(questionIndex).GetPergunta());

            // Verifica se existe alternativas de resposta para exibir
            if (auxiliosList.SemAlternativas(questionIndex))
            {
                MostraBotaoContinuar();
                questionIndex = auxiliosList.GetInfo(questionIndex).GetProxPerguntaSim();
            }
            else
            {
                MostraBotoesSimNao();
            }
        }
        // Caso contrário, termina
        else
        {
            EndAuxilioMinigame();
        }
    }

    /// <summary>
    /// Função que termina a funcionalidade e retorna ao jogo
    /// </summary>
    public void EndAuxilioMinigame()
    {
        isRunning = false;
        telaAuxilio.SetActive(false);
        MapController.instance.RestoreSpeed();
    }

    #region Funções Auxiliares
    /// <summary>
    ///  Função que exibe os botões SIM e NÃo
    /// </summary>
    public void MostraBotoesSimNao()
    {
        botaoSim.SetActive(true);
        botaoNao.SetActive(true);
    }

    /// <summary>
    /// Função que remove os botões SIM e NÃO
    /// </summary>
    public void ApagaBotoesSimNao()
    {
        botaoSim.SetActive(false);
        botaoNao.SetActive(false);
    }

    /// <summary>
    /// Função que mostra o botão CONTINUAR
    /// </summary>
    public void MostraBotaoContinuar()
    {
        botaoContinuar.SetActive(true);
    }

    /// <summary>
    /// Função que remove o botão CONTINUAR
    /// </summary>
    public void ApagaBotaoContinuar()
    {
        botaoContinuar.SetActive(false);
    }

    /// <summary>
    /// Função que retorna o indice de exibição ao valor inicial
    /// </summary>
    public void ResetAll()
    {
        questionIndex = 0;
    }
    #endregion
}
