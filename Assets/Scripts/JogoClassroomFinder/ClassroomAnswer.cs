using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassroomAnswer : MonoBehaviour
{
    [SerializeField]
    private Text resposta; //Texto da resposta atual
    public List<string> valoresValidos; //Lista de valores válidos para o espaço, alterá-los no inspetor
    [SerializeField]
    private string respostaAtual; //Valor para consulta da string que está ativa como resposta
    private int currentPosition = 0;

    public string GetRespostaAtual()
    {
        return respostaAtual;
    }

    private void Start()
    {
        UpdateAnswer();
    }

    /// <summary>
    /// Função de mover um valor para cima ou valor para baixo na lista
    /// </summary>
    /// <param name="sinal">É um inteiro em que o sinal é avaliado, se for positivo, avança na lista, caso o contrário, retrocede</param>
    private void MoveOnList(int sinal)
    {
        int listMaxIndex = valoresValidos.Count-1;
        if (sinal > 0)
        {
            if (currentPosition + 1 > listMaxIndex)  //Se a lista chegou no máximo e o jogador quer ir para frente, volta para o início
            {
                currentPosition = 0;
            }
            else
            {
                currentPosition++;
            }
        }
        else
        {
            if (currentPosition - 1 < 0)  //Se a lista está no valor 0 e o jogador ir para trás, vai para o final da lista
            {
                currentPosition = listMaxIndex;
            }
            else
            {
                currentPosition--;
            }
        }
        UpdateAnswer();
    }

    private void UpdateAnswer()
    {
        respostaAtual = valoresValidos[currentPosition];
        resposta.text = valoresValidos[currentPosition];
    }

    public void GoUp()
    {
        MoveOnList(1);
    }

    public void GoDown()
    {
        MoveOnList(-1);
    }
}
