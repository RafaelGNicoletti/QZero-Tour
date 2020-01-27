using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe para converter de um arquivo de texto em JSON para a classe ClassPergunta
/// </summary>
public class ConverterArquivo : MonoBehaviour
{
    public ClassPergunta temp;
    public Perguntas perguntas;
    public TextAsset file;

    void Start()
    {
        // Cria o conversor
        ConverterFromJson<ClassPergunta> converter = new ConverterFromJson<ClassPergunta>();
        // Converte o arquivo
        temp = converter.Convert(file);
        // Guarda no objeto
        perguntas.SetQuizQuestions(temp);
    }
}
