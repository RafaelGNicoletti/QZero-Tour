using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe genérica para converter de um arquivo em JSON para uma classe do tipo T
/// </summary>
/// <typeparam name="T"></typeparam>
public class ConverterFromJson<T>
{
    public T Convert(TextAsset file)
    {
        return JsonUtility.FromJson<T>(file.text);
    }
}
