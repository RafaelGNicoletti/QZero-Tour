using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Função que converte um arquivo JSON com informações do tipo GlossaryItems em uma GlossaryItems
/// </summary>
public class ConverterArquivoGlossario : MonoBehaviour
{
    public TempGlossary temp;
    public GlossaryItems glossItems;
    public TextAsset file;

    void Start()
    {
        // Cria o conversor
        ConverterFromJson<TempGlossary> converter = new ConverterFromJson<TempGlossary>();
        // Converte para o arquivo temporário
        temp = converter.Convert(file);
        // Grava no GlossaryItems
        glossItems.SetGlossary(temp);
    }
}
