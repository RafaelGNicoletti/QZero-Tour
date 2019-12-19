using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TempQuestionClass
{
    [SerializeField] public List<PseudoString> a;
}

[System.Serializable]
public class PseudoString
{
    [SerializeField] public string[] name;
}