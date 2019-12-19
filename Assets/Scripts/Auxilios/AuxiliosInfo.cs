using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AuxiliosInfo
{
    [SerializeField] private string pergunta;
    [SerializeField] private string textoSim;
    [SerializeField] private string textoNao;
    [SerializeField] private int proxPerguntaSim;
    [SerializeField] private int proxPerguntaNao;
    
    public void Adjust()
    {
        proxPerguntaNao--;
        proxPerguntaSim--;
    }

    public string GetPergunta()
    {
        return pergunta;
    }

    public string GetTextoSim()
    {
        return textoSim;
    }

    public string GetTextoNao()
    {
        return textoNao;
    }

    public int GetProxPerguntaSim()
    {
        return proxPerguntaSim;
    }

    public int GetProxPerguntaNao()
    {
        return proxPerguntaNao;
    }
}
