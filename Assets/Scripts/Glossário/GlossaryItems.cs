using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object que armazena todas as informações dos elementos do glossário
/// </summary>
[CreateAssetMenu(fileName = "GlossaryItemsList", menuName = "My Assets/Glossary Items List")]
public class GlossaryItems : ScriptableObject
{
    public List<GlossaryElement> glossary;

    public void SetGlossary(TempGlossary list)
    {
        glossary = new List<GlossaryElement>();

        foreach(GlossaryElement item in list.glossary)
        {
            glossary.Add(item);
        }
    }
}

/// <summary>
/// Classe temporária para auxiliar na conversão do arquivo JSON
/// </summary>
[System.Serializable]
public class TempGlossary
{
    [SerializeField]
    public GlossaryElement[] glossary;
}
