using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConverterArquivoAuxilios : MonoBehaviour
{
    public TempAux temp;
    public AuxiliosInfoList teste;
    public TextAsset file;

    // Start is called before the first frame update
    void Start()
    {
        ConverterFromJson<TempAux> converter = new ConverterFromJson<TempAux>();
        temp = converter.Convert(file);
        teste.SetAuxiliosInfoList(temp);
    }
}

[System.Serializable]
public class TempAux
{
    [SerializeField] public AuxiliosInfo[] auxiliosList;
}
