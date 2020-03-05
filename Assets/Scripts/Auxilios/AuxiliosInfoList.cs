using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que gera um scriptable object contendo uma lista de AuxiliosInfo
/// </summary>
[CreateAssetMenu(fileName = "Auxilios", menuName = "My Assets/Lista de Auxilios")]
public class AuxiliosInfoList : ScriptableObject
{
    [SerializeField] private AuxiliosInfo[] auxiliosList;

    /// <summary>
    /// Retorna o AuxiliosInfo referente ao índice index
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public AuxiliosInfo GetInfo(int index)
    {
        return auxiliosList[index];
    }

    /// <summary>
    /// Retorna o tamanho da auxiliosList
    /// </summary>
    /// <returns></returns>
    public int GetSize()
    {
        return auxiliosList.Length;
    }

    /// <summary>
    /// Função que armazena em auxiliosList as informações contidas em list
    /// </summary>
    /// <param name="list"></param>
    public void SetAuxiliosInfoList(TempAux list)
    {
        auxiliosList = new AuxiliosInfo[list.auxiliosList.Length];

        for (int i = 0; i < list.auxiliosList.Length; i++)
        {
            auxiliosList[i] = list.auxiliosList[i];
        }
    }

    /// <summary>
    /// Função que verifica se á AuxiliosInfo contida em index possui alternativas ou não
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public bool SemAlternativas(int index)
    {
        bool naoTemAlternativa;

        if (auxiliosList[index].GetTextoSim() == "" && auxiliosList[index].GetTextoNao() == "")
        {
            naoTemAlternativa = true;
        }
        else
        {
            naoTemAlternativa = false;
        }

        return naoTemAlternativa;
    }
}
