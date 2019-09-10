using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// Classe básica para armazenar as informações de um elemento do glossário
/// </summary>
[System.Serializable]
public class GlossaryElement
{
    public string nome;
    public string sigla;
    public string descricao;
    public string link;
    public Sprite logo = null;
}
