﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryNPCSearching : NPCTalk
{
    [SerializeField]
    private string[] falasDeInicio;
    [SerializeField]
    private string[] falasDeSucesso;
    [SerializeField]
    private string[] falasDeFalha;
    [SerializeField]
    private string[] falasSemLivro;
    [SerializeField]
    private SceneLibraryController sceneLibraryController;

    public PlayerInventory playerInventory;
    [SerializeField]
    private Livro correctLivro;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag("Player"))
        {
            playerInventory = collision.transform.parent.GetComponent<PlayerInventory>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag("Player"))
        {
            playerInventory = null;
        }
    }
    public void SetCorrectLivro (Livro livro)
    {
        correctLivro = livro;
    }
    public void FirstConversation(Livro livro)
    {
        SetCorrectLivro(livro);
        falasDeInicio = StringChangeForCorrectLivro(falasDeInicio);
        falasDeSucesso = StringChangeForCorrectLivro(falasDeSucesso);
        falasDeFalha = StringChangeForCorrectLivro(falasDeFalha);
        falasSemLivro = StringChangeForCorrectLivro(falasSemLivro);
        talkTextBox.ShowTalk(falasDeInicio);
    }

    override public void Talk()
    {
        List<InventoryItem> inventory = playerInventory.GetAllItems();

        if (inventory.Capacity == 0)
        {
            Talk(falasSemLivro);
        }

        else if (inventory[0] == null)
        {
            Talk(falasSemLivro);
        }

        else if (inventory[0].GetNome() == correctLivro.GetNome())
        {
            Talk(falasDeSucesso);
            sceneLibraryController.GameComplete();
        }

        else
        {
            Talk(falasDeFalha);
        }
    }

    private string [] StringChangeForCorrectLivro(string[] s)
    {
        for (int i = 0; i < falasDeInicio.Length; i++)
        {
            s[i] = string.Format(s[i], correctLivro.GetNome(), correctLivro.GetCode());
        }

        return s;
    }
}
