using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassroomResultManager : MonoBehaviour
{
    [SerializeField]
    private string answerRight;
    [SerializeField]
    private string answerWrong;
    [SerializeField]
    private Text text;
    private bool buttonChangeScene = false; //Colocar true caso o jogador acerte e o clique no botão seja para mudar a scene.

    public void ButtonScript()//Botão irá chamar essa função, que dependendo do valor do buttonChangeScene, fecha a aba de resultado ou muda de scene
    {
        if (buttonChangeScene)
        {
            //>>>>>>LOAD SCENE ENTRA AQUI<<<<<<<
        }

        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ShowResult(bool acertou, List<string> erros) //Recebe os valores a partir do SceneClassroomFinderController e faz alguma coisa
    {
        gameObject.SetActive(true);
        if (acertou)
        {
            text.text = answerRight;
            buttonChangeScene = true;
        }
        else
        {
            text.text = StringModifierErros(erros);
        }
    }

    private string StringModifierErros(List<string> erros)
    {
        string answerWrongAssist = answerWrong + " " + erros[0];
        erros.RemoveAt(0);

        if (erros.Count != 0)
        {
            foreach (string s in erros)
            {
                answerWrongAssist = answerWrongAssist + ", " + s;
            }
        }

        return answerWrongAssist + ".";
    }
}
