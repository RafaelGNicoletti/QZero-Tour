using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
