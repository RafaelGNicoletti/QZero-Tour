using System.Collections;
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
        private string currentLivro;

        public void ChangeCurrentLivro(string livroName)
        {
            currentLivro = livroName;
            text.text = currentLivro;
        }
    }

    [SerializeField]
    private TextController textController;
    [SerializeField]
    private PlayerInventory playerInventory;

    private void Update()
    {
        Livro livro = (Livro) playerInventory.GetItemByIndex(0);
        if (livro)
        {
            textController.ChangeCurrentLivro(livro.GetNome());
        }
        else
        {
            textController.ChangeCurrentLivro("Nenhum");
        }
    }
}
