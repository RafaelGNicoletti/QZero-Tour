using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntidadeController : MonoBehaviour
{
    public int nMaxEntidades;
    private int nEntidadesCompleted = 0;
    /*
    private void Awake()
    {
        if (Flag)
        {
            CompleteScene();
        } 
    }*/

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
    }

    /// <summary>
    /// Quando todas as entidades forem completadas, aciona a flag dizendo que o mapa terminou.
    /// </summary>
    private void BeatedVerify()
    {
        if (nMaxEntidades == nEntidadesCompleted)
        {
            //Acionar flag
            //Vai ser necessário criar um número referente a flag de verificação, pois esse script estará em mais que uma scene.
        }
    }
}
