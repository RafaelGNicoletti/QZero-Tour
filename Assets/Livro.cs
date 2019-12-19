using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Livro : InventoryItem
{
    [SerializeField]
    private Sprite bookImage;
    [SerializeField]
    private string bookCode;

    public Sprite GetSprite()
    {
        return bookImage;
    }

    public string GetCode()
    {
        return bookCode;
    }
}
