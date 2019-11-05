using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstanteScript : MonoBehaviour, InteractiveObject
{
    [SerializeField]
    private Livro livro;
    private string fixedLivro;
    private PlayerInventory playerInventory;
    private PlayerController playerController;
    [SerializeField]
    private TalkTextBox talkTextBox;
    [SerializeField]
    private string [] warning;
    [SerializeField]
    private string[] getBook;
    [SerializeField]
    private string[] giveBook;

    private void Awake()
    {
        fixedLivro = livro.GetNome();
        for (int i = 0; i<getBook.Length; i++)
        {
            getBook[i] = string.Format(getBook[i], livro.GetNome());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInventory = collision.GetComponentInParent<PlayerInventory>();
            playerController = collision.GetComponentInParent<PlayerController>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInventory = null;
            playerController = null;
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
                TalkWithPlayer(getBook);
                playerInventory.GiveItem(livro);
                livro = livroVerify;
            }
            else if (livroVerify.GetNome() == fixedLivro)
            {
                TalkWithPlayer(giveBook);
                playerInventory.GiveItem(livro);
                livro = livroVerify;
            }
            else
            {
                Debug.Log("Entrou aqui");
                playerInventory.GiveItem(livroVerify);
                TalkWithPlayer(warning);
            }
        }
    }

    public void TalkWithPlayer(string [] s)
    {
        playerController.SetStatus("talking");
        talkTextBox.ShowTalk(s);
    }
}
