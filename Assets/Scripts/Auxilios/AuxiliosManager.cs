using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuxiliosManager : MonoBehaviour
{
    public AuxiliosInfoList auxiliosList;
    public GameObject telaAuxilio;

    public UnityEngine.UI.Text textWindow;
    public GameObject botaoSim, botaoNao, botaoContinuar;

    private int questionIndex;
    private bool isRunning = false;

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

    public void ShowText(string textToShow)
    {
        textWindow.text = textToShow;
    }

    public void RespostaSim()
    {
        ShowText(auxiliosList.GetInfo(questionIndex).GetTextoSim());
        questionIndex = auxiliosList.GetInfo(questionIndex).GetProxPerguntaSim();
        ApagaBotoesSimNao();
        MostraBotaoContinuar();
    }

    public void RespostaNao()
    {
        ShowText(auxiliosList.GetInfo(questionIndex).GetTextoNao());
        questionIndex = auxiliosList.GetInfo(questionIndex).GetProxPerguntaNao();
        ApagaBotoesSimNao();
        MostraBotaoContinuar();
    }

    public void NextQuestion()
    {
        if (questionIndex < auxiliosList.GetSize())
        {
            ApagaBotaoContinuar();
        
            ShowText(auxiliosList.GetInfo(questionIndex).GetPergunta());

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
        else
        {
            EndAuxilioMinigame();
        }
    }

    public void EndAuxilioMinigame()
    {
        isRunning = false;
        telaAuxilio.SetActive(false);
        MapController.instance.RestoreSpeed();
    }

    #region Funções Auxiliares
    public void MostraBotoesSimNao()
    {
        botaoSim.SetActive(true);
        botaoNao.SetActive(true);
    }

    public void ApagaBotoesSimNao()
    {
        botaoSim.SetActive(false);
        botaoNao.SetActive(false);
    }

    public void MostraBotaoContinuar()
    {
        botaoContinuar.SetActive(true);
    }

    public void ApagaBotaoContinuar()
    {
        botaoContinuar.SetActive(false);
    }

    public void ResetAll()
    {
        questionIndex = 0;
    }
    #endregion
}
