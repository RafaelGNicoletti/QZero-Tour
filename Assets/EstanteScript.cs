using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstanteScript : MonoBehaviour, InteractiveObject
{
    [SerializeField]
    private Livro livro;
    [SerializeField]
    private PlayerInventory playerInventory;

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
            playerInventory.GiveItem(livro);
            livro = livroVerify;
        }
    }
}
