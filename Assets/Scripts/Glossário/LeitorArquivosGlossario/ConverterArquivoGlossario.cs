using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConverterArquivoGlossario : MonoBehaviour
{
    public TempGlossary temp;
    public GlossaryItems teste;
    public TextAsset file;

    void Start()
    {
        ConverterFromJson<TempGlossary> converter = new ConverterFromJson<TempGlossary>();
        temp = converter.Convert(file);
        teste.SetGlossary(temp);
    }
}
