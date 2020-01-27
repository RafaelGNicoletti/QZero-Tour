using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Função que converte um arquivo JSON com informações do tipo AuxiliosInfoList em uma AuxiliosInfoList
/// </summary>
public class ConverterArquivoAuxilios : MonoBehaviour
{
    public TempAux temp;
    public AuxiliosInfoList auxList;
    public TextAsset file;

    void Start()
    {
        // Cria o conversor
        ConverterFromJson<TempAux> converter = new ConverterFromJson<TempAux>();
        // Converte para o arquivo temporário
        temp = converter.Convert(file);
        // Grava no AuxiliosInfoList
        auxList.SetAuxiliosInfoList(temp);
    }
}

/// <summary>
/// Lista de auxilios temporária
/// </summary>
[System.Serializable]
public class TempAux
{
    [SerializeField] public AuxiliosInfo[] auxiliosList;
}
