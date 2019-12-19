using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabEntidadeObjSelfManager : MonoBehaviour
{
    public GameObject entidadeNome;
    public GameObject entidadeLogo;

    public void UpdateInfo(EntidadeInfo info)
    {
        entidadeNome.GetComponent<EntidadeObjInterativo>().nome = info.id;
        entidadeLogo.GetComponent<EntidadeObjInterativo>().nome = info.id;
        entidadeLogo.GetComponentInChildren<Image>().sprite = info.spriteImg;
    }
}
