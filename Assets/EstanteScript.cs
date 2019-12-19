using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstanteScript : MonoBehaviour, InteractiveObject
{
    [SerializeField]
    private Livro livro;  //Livro atual que está na estante
    private string fixedLivro; //Livro que pertecente a estante
    private PlayerInventory playerInventory;
    private PlayerController playerController;
    [SerializeField]
    private TalkTextBox talkTextBox; //Referencia ao talkTextBox da scene, para apresentar as falas.
    [SerializeField]
    private string [] warning; //Aviso que o jogador recebe quando ele tenta devolver um livro no local errado
    [SerializeField]
    private string[] areaOfNoInterest; //Aviso que o jogador recebe quando o jogador não está segurando nenhum livro e a estante não tem nenhum livro.
    [SerializeField]
    private string[] getBook; //Texto quando o jogador pega um livro da estante
    [SerializeField]
    private string[] giveBook; //Texto quando o jogador dá o livro para a estante

    private void Awake()
    {
        if (livro)
        {
            fixedLivro = livro.GetNome();
            for (int i = 0; i<getBook.Length; i++)
            {
                getBook[i] = string.Format(getBook[i], livro.GetNome());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag("Player"))
        {
            playerInventory = collision.GetComponentInParent<PlayerInventory>();
            playerController = collision.GetComponentInParent<PlayerController>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.CompareTag("Player"))
        {
            playerInventory = null;
            playerController = null;
        }
    }

    public void Interact()
    {
        TradeItem();
    }

    /// <summary>
    /// Função que devolve o item a estante ou então pega o item dela.
    /// </summary>
    private void TradeItem()
    {
        Livro livroVerify = null;

        if (playerInventory)
        {
            livroVerify = (Livro) playerInventory.TakeFirstItem();
            if (livroVerify == null && livro == null)
            {
                TalkWithPlayer(areaOfNoInterest);
            }
            else if (livroVerify == null)
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
