using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InfoList : ScriptableObject
{
    [System.Serializable]
    private class EntidadeInfo
    {
        public string id;
        public string info;
    }

    [SerializeField]
    private List<EntidadeInfo> entidadeInfoList;

    public string GetInfo(string id)
    {
        return entidadeInfoList.Find(x => x.id.Equals(id)).info;
    }
}
