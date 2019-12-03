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
}
