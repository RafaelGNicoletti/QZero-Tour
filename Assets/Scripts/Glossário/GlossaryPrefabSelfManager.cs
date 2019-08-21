using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que contém as funções básicas para o funcionamento dos ítens do glossário
/// </summary>
public class GlossaryPrefabSelfManager : MonoBehaviour
{
    public UnityEngine.UI.Text headerText;
    public UnityEngine.UI.Text contentText;

    /// <summary>
    /// Função que ativa e desativa o GameObject atrelado
    /// </summary>
    /// <param name="value"></param>
    public void Toggle(bool value)
    {
        gameObject.SetActive(value);
    }

    /// <summary>
    /// Função que atualiza as informações do prefab atrelado
    /// </summary>
    /// <param name="glossaryElement"></param>
    public void UpdatePrefabs(GlossaryElement glossaryElement)
    {
        headerText.text = glossaryElement.nome;
        contentText.text = glossaryElement.sigla;
    }
}
