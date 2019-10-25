using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstanteScript : MonoBehaviour, InteractiveObject
{
    [SerializeField]
    private Livro livro;
    private string fixedLivro;
    private PlayerInventory playerInventory;
    [SerializeField]
    private TalkTextBox talkTextBox;
    private string [] warning = new string[1];

    private void Awake()
    {
        warning[0] = "Você precisa devolver seu livro no lugar correto antes de trocar por outro!";
        fixedLivro = livro.GetNome();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInventory = collision.GetComponentInParent<PlayerInventory>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInventory = null;
        }
    }

    public void Interact()
    {
        TradeItem();
    }

    public void TradeItem()
    {
        Livro livroVerify = null;

        if (playerInventory)
        {
            livroVerify = (Livro) playerInventory.TakeFirstItem();
            if (livroVerify == null)
            {
                playerInventory.GiveItem(livro);
                livro = livroVerify;
            }
            else if (livroVerify.GetNome() == fixedLivro)
            {
                playerInventory.GiveItem(livro);
                livro = livroVerify;
            }
            else
            {
                playerInventory.GiveItem(livroVerify);
                talkTextBox.ShowTalk(warning);
            }
        }
    }
}
