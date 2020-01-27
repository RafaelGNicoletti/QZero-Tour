using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe temporário para auxiliar na inserção das perguntas do quiz
/// </summary>
[System.Serializable]
public class TempQuestionClass
{
    [SerializeField] public List<PseudoString> a;
}

/// <summary>
/// Subclasse para auxiliar na inserção das perguntas do quiz
/// </summary>
[System.Serializable]
public class PseudoString
{
    [SerializeField] public string[] name;
}