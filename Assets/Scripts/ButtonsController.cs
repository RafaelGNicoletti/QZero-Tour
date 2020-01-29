using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

[CreateAssetMenu(fileName = "ButtonsController", menuName = "My Assets/Controlador de Botões")]
public class ButtonsController : ScriptableObject
{
    //private int selectedButton = -1;

    /// <summary>
    /// Função que verifica automáticamente se a alternativa selecionada é a correta
    /// </summary>
    /// <param name="value"></param>
    public void AnswerSelected(int value)
    {
        QuizManager.instance.CheckAnswer(value);
    }

    //public void FadeOutPanel()
    //{
    //    GameObject.Find("StartPanel").GetComponent<Animator>().SetTrigger("FadeOut");
    //}

    /// <summary>
    /// Função que configura e inicia o quiz
    /// </summary>
    /// <param name="quizManager"></param>
    public void StartQuiz(GameObject quizManager)
    {
        QuizManager manager = quizManager.GetComponent<QuizManager>();
        manager.SetDificulty(0);
        manager.TutorialScreen(false);
        manager.TurnOnTela2();
        manager.PrepareNewQuestion();
        //GameObject.Find("QuizManager").GetComponent<QuizManager>().PrepareNewQuestion();
    }

    /// <summary>
    /// Função que inicia o tutorial do quiz
    /// </summary>
    /// <param name="quizManager"></param>
    public void OpenQuizTutorial(GameObject quizManager)
    {
        QuizManager manager = quizManager.GetComponent<QuizManager>();
        manager.TutorialScreen(true);
    }

    /// <summary>
    /// Função que carrega a Scene name
    /// </summary>
    /// <param name="Scene name"></param>
    public void SimpleLoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    /// <summary>
    /// Função que salva o índice do avatar no GameManager
    /// </summary>
    /// <param name="index"></param>
    public void SelectAvatar(int index)
    {
        GameManager.instance.SetAvatarSelectedIndex(index);
    }

    /// <summary>
    /// Função que salva o nome do player no GameManager
    /// </summary>
    /// <param name="gameObject"></param>
    public void FillPlayerName(GameObject gameObject)
    {
        GameManager.instance.SetPlayerName(gameObject.GetComponent<UnityEngine.UI.Text>().text);
    }

    /// <summary>
    /// Função que desbloqueia o uso do button
    /// </summary>
    /// <param name="button"></param>
    public void UnblockButton(GameObject button)
    {
        //if (GameManager.instance.GetPlayerName() != "" && GameManager.instance.GetAvatarSelectedIndex() != -1)
        //{
        //GameObject.Find(buttonName).GetComponent<UnityEngine.UI.Button>().interactable = true;
        //}
        button.GetComponent<UnityEngine.UI.Button>().interactable = true;
    }
    
    /// <summary>
    /// Função para abrir um link no navegador em uma nova aba
    /// </summary>
    /// <param name="siteName"></param>
    public void OpenLinkJSPlugin(string siteName)
    {
#if !UNITY_EDITOR
      openWindow("http://"+siteName);
#endif
    }

    [DllImport("__Internal")]
    private static extern void openWindow(string url);

    /// <summary>
    /// Função que ativa o trigger do animator do canvas da scene atual
    /// </summary>
    /// <param name="trigger"></param>
    public void SetTrigger(string trigger)
    {
        GameObject.Find("Canvas").GetComponent<Animator>().SetTrigger(trigger);
    }

    /// <summary>
    /// Função que carrega a scene salva como anterior no GameManager
    /// </summary>
    public void LoadLastScene()
    {
        SceneManager.LoadScene(GameManager.instance.GetLastSceneName());
    }
}
