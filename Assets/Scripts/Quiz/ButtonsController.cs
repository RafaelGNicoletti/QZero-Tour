using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

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

    public void StartQuiz(GameObject quizManager)
    {
        QuizManager manager = quizManager.GetComponent<QuizManager>();
        manager.SetDificulty(0);
        manager.TurnOnTela2();
        manager.PrepareNewQuestion();
        //GameObject.Find("QuizManager").GetComponent<QuizManager>().PrepareNewQuestion();
    }

    public void SimpleLoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void SelectAvatar(int index)
    {
        GameManager.instance.SetAvatarSelectedIndex(index);
    }

    public void FillPlayerName(GameObject gameObject)
    {
        GameManager.instance.SetPlayerName(gameObject.GetComponent<UnityEngine.UI.Text>().text);
    }

    public void UnblockButton(string buttonName)
    {
        if (GameManager.instance.GetPlayerName() != "" && GameManager.instance.GetAvatarSelectedIndex() != -1)
        {
            GameObject.Find(buttonName).GetComponent<UnityEngine.UI.Button>().interactable = true;
        }
    }
    
    public void OpenLinkJSPlugin(string siteName)
    {
#if !UNITY_EDITOR
      openWindow("http://"+siteName);
#endif
    }

    public void OpenLinkJSPluginTeste()
    {
#if !UNITY_EDITOR
      openWindow("http://www.youtube.com.br");
#endif
    }
    
    [DllImport("__Internal")]
    private static extern void openWindow(string url);
}
