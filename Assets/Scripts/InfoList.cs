using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InfoList : ScriptableObject
{
    // Criada uma classe externa (necessidade de utilizar em outros lugares)
    //[System.Serializable]
    //private class EntidadeInfo
    //{
    //    public string id; //Identificação do dado
    //    public UnityEngine.UI.Image img; //Imagem do dado
    //    public string info; //Informação sobre o dado.
    //}

    [SerializeField]
    private List<EntidadeInfo> entidadeInfoList;

    /// <summary>
    /// Recebe um ID e devolve o texto vinculado àquele ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetInfo(string id)
    {
        return entidadeInfoList.Find(x => x.id.Equals(id)).info;
    }

    public EntidadeInfo GetEntidade(int i)
    {
        return entidadeInfoList[i];
    }
}
