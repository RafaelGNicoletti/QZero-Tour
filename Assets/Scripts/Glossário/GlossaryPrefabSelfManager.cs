using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

/// <summary>
/// Classe que contém as funções básicas para o funcionamento dos ítens do glossário
/// </summary>
public class GlossaryPrefabSelfManager : MonoBehaviour
{
    public UnityEngine.UI.Text nomeText;
    public UnityEngine.UI.Text siglaText;
    public UnityEngine.UI.Text descricaoText;
    public UnityEngine.UI.Text linkText;
    public UnityEngine.UI.Image logoSprite;

    /// <summary>
    /// Função que ativa e desativa o GameObject atrelado
    /// </summary>
    /// <param name="value"></param>
    public void Toggle(GameObject gameObject)
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Função que atualiza as informações do prefab atrelado
    /// </summary>
    /// <param name="glossaryElement"></param>
    public void UpdatePrefabs(GlossaryElement glossaryElement)
    {
        nomeText.text = glossaryElement.nome;
        siglaText.text = glossaryElement.sigla;
        descricaoText.text = glossaryElement.descricao;
        linkText.text = glossaryElement.link;
        if (glossaryElement.logo != null)
        {
            logoSprite.sprite = glossaryElement.logo;
            logoSprite.preserveAspect = true;
        }
        else
        {
            logoSprite.color = new Color(0, 0, 0, 0);
        }
    }

    /// <summary>
    /// Função para abrir um link no navegador em uma nova aba
    /// </summary>
    /// <param name="siteName"></param>
    public void OpenInternalLinkJSPlugin()
    {
#if !UNITY_EDITOR
      openWindow("http://"+linkText.text);
#endif
    }
    
    [DllImport("__Internal")]
    private static extern void openWindow(string url);
}
