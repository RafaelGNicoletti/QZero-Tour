using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Facilita na obtenção de uma lista com todos os livros.
/// </summary>
public class LibraryLivroManager : MonoBehaviour
{
    private Livro[] livros;

    private void Awake()
    {
        livros = GetComponentsInChildren<Livro>();
    }

    public Livro[] GetLivros()
    {
        return livros;
    }
}
