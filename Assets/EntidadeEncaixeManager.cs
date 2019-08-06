using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntidadeEncaixeManager : MonoBehaviour
{
    public GameObject encaixeNome;
    public GameObject encaixeLogo;
    public GameObject encaixeDescricao;
    public InfoList entidadeInfoList;

    private bool duoComplete = false;

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
        }
    }

    private void Update()
    {
        CheckNames();
    }
}
