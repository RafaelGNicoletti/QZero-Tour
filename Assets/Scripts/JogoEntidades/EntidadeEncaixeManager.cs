using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntidadeEncaixeManager : MonoBehaviour
{
    public GameObject encaixeNome; //Encaixe de nome que será verificado
    public GameObject encaixeLogo; //Encaixe de logo que será verificado
    public GameObject encaixeDescricao; //Encaixe de descrição que será atualizado.
    public InfoList entidadeInfoList; //ScriptableObject que possui a lista das entidades e a informação delas.
    public SceneEntidadeController sceneEntidadeController;

    private bool duoComplete = false;

    /// <summary>
    /// Verifica se o logo e o nome possuem o mesmo id;
    /// </summary>
    private void CheckNames()
    {
        string encaixeLogoString = encaixeLogo.GetComponent<EntidadeEncaixe>().id;
        string encaixeNomeString = encaixeNome.GetComponent<EntidadeEncaixe>().id;

        if (!duoComplete && encaixeNomeString != "-1" && encaixeNomeString == encaixeLogoString)
        {
            encaixeDescricao.GetComponentInChildren<Text>().text = entidadeInfoList.GetInfo(encaixeLogoString);
            encaixeNome.GetComponent<EntidadeEncaixe>().LockObject();
            encaixeLogo.GetComponent<EntidadeEncaixe>().LockObject();
            duoComplete = true;
            sceneEntidadeController.CorrectAnswer();
        }
    }

    private void Update()
    {
        CheckNames();
    }
}
