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
}
