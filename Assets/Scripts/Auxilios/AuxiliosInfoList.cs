using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Auxilios", menuName = "My Assets/Lista de Auxilios")]
public class AuxiliosInfoList : ScriptableObject
{
    [SerializeField] private AuxiliosInfo[] auxiliosList;

    public AuxiliosInfo GetInfo(int index)
    {
        return auxiliosList[index];
    }

    public int GetSize()
    {
        return auxiliosList.Length;
    }

    public void SetAuxiliosInfoList(TempAux list)
    {
        auxiliosList = new AuxiliosInfo[list.auxiliosList.Length];

        for (int i = 0; i < list.auxiliosList.Length; i++)
        {
            auxiliosList[i] = list.auxiliosList[i];
        }
    }

    public bool SemAlternativas(int index)
    {
        bool temAlternativa;

        if (auxiliosList[index].GetTextoSim() == "" && auxiliosList[index].GetTextoNao() == "")
        {
            temAlternativa = true;
        }
        else
        {
            temAlternativa = false;
        }

        return temAlternativa;
    }
}
