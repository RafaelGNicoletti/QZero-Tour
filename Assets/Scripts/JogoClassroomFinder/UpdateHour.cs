using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class UpdateHour : MonoBehaviour
{
    /// <summary>
    /// Atualiza o texto de hour de acordo com a hora, no formato "hh:mm"
    /// </summary>
    [SerializeField]
    private Text hour;
    void LateUpdate()
    {
        hour.text = System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString();
    }
}
