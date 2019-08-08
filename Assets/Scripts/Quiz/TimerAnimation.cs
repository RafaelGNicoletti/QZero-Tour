using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que gerencia a animação do timer animado
/// </summary>
public class TimerAnimation : MonoBehaviour
{
    public Vector2 posInicial;
    public Vector2 posFinal;
    private Vector2 pos;
    private int count = 0;
    public GameObject movingObject;

    private float barProgression;

    /// <summary>
    /// Função que calcula a posição do elétron
    /// </summary>
    /// <param name="x"></param>
    private void Equation(float x)
    {
        pos.x = posInicial.x + x * (posFinal.x - posInicial.x) / TimeManager.instance.repeatInstances;
        pos.y = posInicial.y + x * (posFinal.x - posInicial.x) / TimeManager.instance.repeatInstances * ((posFinal.y - posInicial.y) / (posFinal.x - posInicial.x)) +
            Mathf.Sin(x * Mathf.PI / (TimeManager.instance.repeatInstances / 2)) * (posFinal.y - posInicial.y) / (TimeManager.instance.repeatInstances / 4);
    }

    /// <summary>
    /// Função que controla a animação
    /// </summary>
    /// <returns></returns>
    private IEnumerator Animation_MovingEletron()
    {
        // Calcula a nova posição
        Equation(count);
        // Atualiza a posição do elétron
        movingObject.transform.localPosition = new Vector3(pos.x, pos.y);
        // incrementa o contador de iterações
        count++;
        yield return new WaitForSeconds(0);
    }

    /// <summary>
    /// Função que reinicia a animação
    /// </summary>
    public void RestarAnimation()
    {
        count = 0;
        StartCoroutine(Animation_MovingEletron());
    }

    /// <summary>
    /// Função que chama a próxima transição da animação
    /// </summary>
    public void NextTransition()
    {
        StartCoroutine(Animation_MovingEletron());
    }
}
