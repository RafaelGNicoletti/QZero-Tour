using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConverterArquivo : MonoBehaviour
{
    public ClassPergunta temp;
    public Perguntas teste;
    public TextAsset file;

    // Start is called before the first frame update
    void Start()
    {
        ConverterFromJson<ClassPergunta> converter = new ConverterFromJson<ClassPergunta>();
        temp = converter.Convert(file);
        teste.SetQuizQuestions(temp);
    }
}
