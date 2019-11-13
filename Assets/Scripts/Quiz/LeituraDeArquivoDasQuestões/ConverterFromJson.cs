using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConverterFromJson<T>
{
    public T Convert(TextAsset file)
    {
        return JsonUtility.FromJson<T>(file.text);
    }
}
