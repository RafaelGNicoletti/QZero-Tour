using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsável por controlar o funcionamento do glossário
/// </summary>
public class GlossaryManager : MonoBehaviour
{
    public GlossaryManager instance;
    public GlossaryItems glossaryList;

    public GameObject glossaryPrefab;
    public GameObject glossaryWindow;

    public UnityEngine.UI.Text searchBarText;

    private List<GameObject> glossaryItems = new List<GameObject>();
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance != this)
        {
            Destroy(gameObject);
        }

        SortGlossaryItemList(glossaryList);
        UpdateGlossaryWindow(glossaryList.glossary);
    }

    /// <summary>
    /// Função que atualiza os elementso existentes no glossário
    /// </summary>
    /// <param name="glossaryListToShow"></param>
    public void UpdateGlossaryWindow(List<GlossaryElement> glossaryListToShow)
    {
        // Remove os elementos que estão sendo exibidos
        foreach(GameObject item in glossaryItems)
        {
            // Destroi os objetos
            Destroy(item);
        }

        // Cria uma lista nova
        glossaryItems = new List<GameObject>();

        // Exibe os elementos que estão na lista
        for (int i = 0; i < glossaryListToShow.Count; i++)
        {
            // Instancia um novo prefab
            GameObject temp = Instantiate(glossaryPrefab, glossaryWindow.transform);
            // Atualiza os valores da prefab
            temp.GetComponent<GlossaryPrefabSelfManager>().UpdatePrefabs(glossaryListToShow[i]);
            // Adiciona o elemento instânciado a lista de elementos existentes
            glossaryItems.Add(temp);
        }
    }

    /// <summary>
    /// Função que organiza os elementos da lista
    /// </summary>
    /// <param name="listToSort"></param>
    /// <returns></returns>
    public List<GlossaryElement> SortGlossaryItemList(GlossaryItems listToSort)
    {
        // Gera uma lista nova para armazenar a lista organizada
        List<GlossaryElement> temp = new List<GlossaryElement>();

        // Pega os elementos que devem ser organizados
        temp = listToSort.glossary;
        // Organiza de acordo com a função anônima delegate a lista em ordem alfabética
        temp.Sort(delegate (GlossaryElement a, GlossaryElement b)
        {
            // Compara as expressões (string da classe GlossaryElement)
            return a.nome.CompareTo(b.nome);
        });

        return temp;
    }

    /// <summary>
    /// Função que realiza a busca de todas as expressões que possuem a expressão desejada no glossário
    /// </summary>
    /// <param name="listToSearch"></param>
    /// <param name="expressionToFind"></param>
    /// <returns></returns>
    public List<GlossaryElement> SearchExpression(GlossaryItems listToSearch, string expressionToFind)
    {
        // Cria uma lista nova para armazenar os itens encontrados
        List<GlossaryElement> temp = new List<GlossaryElement>();

        // Pega os elementos que devem ser varridos
        temp = listToSearch.glossary;
        // Realiza a busca de acordo com a função anônima delegate
        temp = temp.FindAll(delegate (GlossaryElement a)
        {
            // Se a expressão do GlossaryElement conter a expressão procurada, armazena
            // Ignora maiúsculas e minúsculas
            if (a.nome.ToUpper().Contains(expressionToFind.ToUpper())) return true;
            else return false;
        });

        return temp;
    }

    /// <summary>
    /// Função que chama a busca de expressões e atualiza a tela do glossário com as expressões encontradas
    /// </summary>
    public void Search()
    {
        // Gera uma lista com as expressões encontradas
        List<GlossaryElement> temp = SearchExpression(glossaryList, searchBarText.text);
        
        // PARA TESTES
        //foreach (GlossaryElement g in temp)
        //{
        //    Debug.Log(g.expression);
        //}

        // Atualiza a tela com as expressões encontradas
        UpdateGlossaryWindow(SearchExpression(glossaryList, searchBarText.text));
    }
}
