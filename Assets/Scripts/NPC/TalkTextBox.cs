using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkTextBox : MonoBehaviour
{
    public GameObject background, text, continuar;
    [SerializeField] private PlayerInteract playerInteract;

    private int currentText;
    private string[] textToShow;
    public bool textBoxActive;

    public void Awake()
    {
        SetGameObjectOff();
    }

    private void Start()
    {
        playerInteract = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteract>(); //Procura o jogador na scene
    }

    /// <summary>
    /// Função chamada para começar a conversa, pega a lista de strings, ativa o balão de conversa e o inicia.
    /// </summary>
    /// <param name="talk"></param>
    public void ShowTalk(string[] talk)
    {
        textToShow = talk;
        SetGameObjectOn();
        StartMessage();
    }

    /// <summary>
    /// Coloca no estado inicial os textos
    /// </summary>
    private void StartMessage()
    {
        currentText = 0;
        InputText(textToShow[currentText]);
    }
    
    /// <summary>
    /// Avança para o próximo texto
    /// </summary>
    public void NextText()
    {
        if (currentText == (textToShow.Length-1)) ///Caso esse seja o último texto
        {
            SetGameObjectOff();
            playerInteract.StopTalking();
        }

        else
        {
            currentText++;
            InputText(textToShow[currentText]);
        }
    }

    /// <summary>
    /// Liga os filhos do gameObject
    /// </summary>
    private void SetGameObjectOn()
    {
        textBoxActive = true;
        background.SetActive(true);
        text.SetActive(true);
        continuar.SetActive(true);
    }

    /// <summary>
    /// Desliga os filhos do gameObject
    /// </summary>
    private void SetGameObjectOff()
    {
        textBoxActive = false;
        background.SetActive(false);
        text.SetActive(false);
        continuar.SetActive(false);
    }

    /// <summary>
    /// Torna visível a string s no balão de fala.
    /// </summary>
    /// <param name="s"></param>
    private void InputText(string s)
    {
        text.GetComponent<Text>().text = s;
    }

}
