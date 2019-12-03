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

            GameObject.Find("Canvas").GetComponent<Animator>().Play("SetUI");
            GameObject.Find("Canvas").GetComponent<Animator>().speed = -1;
            GameObject.Find("MapController").GetComponent<MapController>().ClearSpeed();
            telaAuxilio.SetActive(true);
            ResetAll();
            ShowText(auxiliosList.GetInfo(questionIndex).GetPergunta());
            MostraBotaoContinuar();
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
        ApagaBotaoContinuar();

        if (questionIndex == 0)
        {
            ShowText(auxiliosList.GetInfo(questionIndex + 1).GetPergunta());
            MostraBotoesSimNao();
            questionIndex++;
        }
        else if (questionIndex < auxiliosList.GetSize() - 1)
        {
            ShowText(auxiliosList.GetInfo(questionIndex).GetPergunta());
            MostraBotoesSimNao();
        }
        else if (questionIndex == auxiliosList.GetSize() - 1)
        {
            ShowText(auxiliosList.GetInfo(questionIndex).GetPergunta());
            MostraBotaoContinuar();
            questionIndex++;
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
        GameObject.Find("MapController").GetComponent<MapController>().RestoreSpeed();

        GameObject.Find("Canvas").GetComponent<Animator>().Play("SetUI");
        GameObject.Find("Canvas").GetComponent<Animator>().speed = 1;
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
