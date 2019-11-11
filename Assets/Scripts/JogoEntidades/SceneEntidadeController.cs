using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntidadeController : MonoBehaviour
{
    public int nMaxEntidades;
    private int nEntidadesCompleted = 0;
    public GameObject[] duplaNomeLogo;
    public int[] numEntidadeExibida;
    public InfoList entidadeList;

    public string keyName;

    private void Awake()
    {
        GameManager.instance.AddDataToJogoEntidadeDictionary(keyName, false);

        /// Utilizado para testar duplas aleátoriamentes - Duplas existentes em cada scene serão colocadas manualmente 
        /// na variável numEntidadeExibida no inspector do UNITY na versão final
        #region Temporário - sorteia 4 aleatórios para exibir
        List<int> list = new List<int>();
        for (int j = 0; j < nMaxEntidades; j++)
        {
            list.Add(j);
        }

        int numberSelected;

        for (int k = 0; k < nMaxEntidades; k++)
        {
            if (list.Count != 0)
            {
                /// Seleciona o número aleatório
                numberSelected = list[Random.Range(0, list.Count - 1)];
                /// Remove da lisata para não ser selecionado novamente
                list.Remove(numberSelected);
            }
            else
            {
                numberSelected = 0;
            }

            //Debug.Log(numberSelected);
        }
        #endregion

        int i = 0;
        EntidadeInfo entidadeExibida;
        foreach (GameObject dupla in duplaNomeLogo)
        {
            entidadeExibida = entidadeList.GetEntidade(numEntidadeExibida[i]);
            dupla.GetComponent<PrefabEntidadeObjSelfManager>().UpdateInfo(entidadeExibida);
            i++;
        }

        if (GameManager.instance.GetDataToJogoEntidadeDictionary(keyName))
        {
            CompleteScene();
        }
    }

     /// <summary>
     /// Caso a fase já tenha sido completada, completa ela de forma manual quando o jogador entra nela.
     /// </summary>
    private void CompleteScene()
    {
        ///É necessário que a scene esteja organizada em relação aos logos e nomes. Pois o primeiro nome da hirearquia será o nome[0]
        ///e o primeiro logo da hirearquia será o logo[0]
        GameObject[] nomeEncaixe = GameObject.FindGameObjectsWithTag("EncaixeNome");
        GameObject[] logoEncaixe = GameObject.FindGameObjectsWithTag("EncaixeLogo");
        GameObject[] nome = GameObject.FindGameObjectsWithTag("EntidadeNome");
        GameObject[] logo = GameObject.FindGameObjectsWithTag("EntidadeLogo");

        ///Coloca todos os objetos nos lugares e ativa a função de colocá-los nos encaixes.
        for (int i = 0; i<nomeEncaixe.Length; i++)
        {
            nome[i].transform.position = nomeEncaixe[i].transform.position;
            nomeEncaixe[i].GetComponent<EntidadeEncaixe>().PutObjectInside(nome[i]);
            logo[i].transform.position = logoEncaixe[i].transform.position;
            logoEncaixe[i].GetComponent<EntidadeEncaixe>().PutObjectInside(logo[i]);
        }
    }

    /// <summary>
    /// Aumenta o número do total de entidades que foram completadas.
    /// </summary>
    public void CorrectAnswer()
    {
        nEntidadesCompleted++;

        if (nEntidadesCompleted == nMaxEntidades)
        {
            BeatedVerify();
        }
    }

    /// <summary>
    /// Quando todas as entidades forem completadas, aciona a flag dizendo que o mapa terminou.
    /// </summary>
    private void BeatedVerify()
    {
        if (nMaxEntidades == nEntidadesCompleted)
        {
            GameManager.instance.SetDataToJogoEntidadeDictionary(keyName, true);
            //Acionar flag
            //Vai ser necessário criar um número referente a flag de verificação, pois esse script estará em mais que uma scene.
        }
    }
}
