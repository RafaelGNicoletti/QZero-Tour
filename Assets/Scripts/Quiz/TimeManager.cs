using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que gerencia o timer
/// </summary>
public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    public float timeToWait;

    // Variável usada para armazenar uma referencia a corrotina (que deve ser interrompida caso necessário)
    private Coroutine timerCoroutineInstance = null;

    public UnityEngine.UI.Image progressionBar;
    public float totalTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Função que inicia o timer
    /// </summary>
    public void StartTimer()
    {
        #region Timer em barra
        progressionBar.fillAmount = 1;
        StartCoroutine(Timer());
        #endregion

        #region Timer Animado
        //StartTimer_MovingEletron();
        #endregion
    }

    /// <summary>
    /// Função que conta o tempo e atualiza o timer em barra
    /// </summary>
    /// <returns></returns>
    public IEnumerator Timer()
    {
        // Se a barra não estiver vazia
        if (progressionBar.fillAmount > 0)
        {
            // Decrementa o timer
            progressionBar.fillAmount -= (Time.deltaTime / totalTime);
            // Aguarda o fim do frame
            yield return new WaitForEndOfFrame();
            // Chama a função novamente
            timerCoroutineInstance = StartCoroutine(Timer());
        }
        // Caso contrário
        else
        {
            // Chama a função que lida com o fim do tempo
            StartCoroutine(EndOfTime());
        }
    }

    /// <summary>
    /// Função que lida com o estouro do timer
    /// </summary>
    /// <returns></returns>
    public IEnumerator EndOfTime()
    {
        // Chama a função que lida com o fim do tempo no QuizManager
        StartCoroutine(QuizManager.TimeOver());
        yield return new WaitForSeconds(0);
    }

    /// <summary>
    /// Função que para o timer manualmente
    /// </summary>
    public void EndTimer()
    {
        //Debug.Log("Timer stopped");
        StopCoroutine(timerCoroutineInstance);
    }
}