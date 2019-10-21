﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLibraryController : MonoBehaviour
{
    [System.Serializable]
    public class TextController
    {
        [SerializeField]
        private Text text;
        [SerializeField]
        private Image bookImage;
        private Livro currentLivro;

        public void ChangeCurrentLivro(Livro livro)
        {
            currentLivro = livro;
            if (currentLivro)
            {
                text.text = currentLivro.GetNome();
                ChangeImageCurrentLivro(currentLivro.GetSprite());
            }
            else
            {
                text.text = "Vazio";
                ChangeImageCurrentLivro(null);
            }
        }

        private void ChangeImageCurrentLivro(Sprite image)
        {
            if (image)
            {
                bookImage.sprite = image;
                ChangeTransparency(1);
            }
            else
            {
                bookImage.sprite = null;
                ChangeTransparency(0);
            }
        }

        /// <summary>
        /// Muda a transparência da imagem, sendo 0 = transparente, 1 = opaco
        /// </summary>
        /// <param name="transparency"></param>
        private void ChangeTransparency(float transparency)
        {
            var tempColor = bookImage.color;
            tempColor.a = transparency;
            bookImage.color = tempColor;
        }

        public Livro GetCurrentLivro()
        {
            return currentLivro;
        }
    }

    [SerializeField]
    private TextController textController;
    [SerializeField]
    private PlayerInventory playerInventory;
    [SerializeField]
    private LibraryLivroManager libraryLivroManager;
    [SerializeField]
    private Livro correctLivro;
    [SerializeField]
    private TalkTextBox talkTextBox;
    [SerializeField]
    private string[] falasDeInicio;
    [SerializeField]
    private string[] falaDeSucesso;
    [SerializeField]
    private string[] falaDeFalha;

    private void Start()
    {
        RandomLivroSelector();
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        textController.ChangeCurrentLivro(null);
        FirstConversation();

    }

    private void FirstConversation()
    {
        falaDeSucesso[0] =  falaDeSucesso[0] +" "+ correctLivro.GetNome();
        talkTextBox.ShowTalk(falaDeSucesso);
    }

    private void GameComplete()
    {
        
    }

    private void RandomLivroSelector()
    {
        Livro[] livros = libraryLivroManager.GetLivros();
        int n = Random.Range(0, livros.Length);
        correctLivro = livros[n];
    }
    private void Update()
    {
        Livro livro = (Livro) playerInventory.GetItemByIndex(0);
        if (livro != textController.GetCurrentLivro())
        {
            if (livro)
            {
                textController.ChangeCurrentLivro(livro);
            }
            else
            {
                textController.ChangeCurrentLivro(livro);
            }
        }
    }
}
