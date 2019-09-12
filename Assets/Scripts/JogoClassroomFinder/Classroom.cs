using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ClassroomCollection
{
    public List<Classroom> classRooms;
}

[System.Serializable]
public class Classroom
{
    public string codSala;
    [SerializeField]
    private string bloco;
    [SerializeField]
    private string torre;
    [SerializeField]
    private string andar;
    [SerializeField]
    private string sala;

    /// <summary>
    /// Entre arrumar a tabela e colocar strings como "º" e acentos, que não são lidas no conversor para JSON, é melhor corrigir os valores através desta função.
    /// </summary>
    public void FixString()
    {
        if (bloco.ToUpper().Equals("A") || bloco.ToUpper().Equals("B"))
        {
            bloco = "BLOCO " + bloco;
        }

        if (!torre.ToUpper().Equals("-"))
        {
            torre = "TORRE " + torre;
        }

        if (andar.ToUpper().Equals("TERREO"))
        {
            andar = "TÉRREO";
        }
        else
        {
            andar = andar + "º ANDAR";
        }

        sala = "SALA " + sala;
    }

    /// <summary>
    /// Verifica se os valores dados a ele batem com os valores que estão nele
    /// </summary>
    /// <param name="bloco"></param>
    /// <param name="torre"></param>
    /// <param name="andar"></param>
    /// <param name="sala"></param>
    /// <returns>Devolve um booleano que indica se são iguais. E uma lista de string com os termos errados.</returns>
    public (bool, List<string>) GetVerification(string bloco, string torre, string andar, string sala)
    {
        List<string> camposErrados = new List<string>();
        bool errado = false;

        if (!bloco.ToUpper().Equals(this.bloco))
        {
            errado = true;
            camposErrados.Add("bloco");
        }
        if (!torre.ToUpper().Equals(this.torre))
        {
            errado = true;
            camposErrados.Add("torre");
        }
        if (!andar.ToUpper().Equals(this.andar))
        {
            errado = true;
            camposErrados.Add("andar");
        }
        if (!sala.ToUpper().Equals(this.sala))
        {
            errado = true;
            camposErrados.Add("sala");
        }

        return (!errado, camposErrados);
    }
}
