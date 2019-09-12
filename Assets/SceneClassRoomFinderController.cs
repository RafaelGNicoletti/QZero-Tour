using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneClassRoomFinderController : MonoBehaviour
{
    public List<ClassroomAnswer> classroomAnswers;
    public ClassRoomBoard classRoomBoard;
    [SerializeField]
    private ClassRoom currentClassRoom;

    private void Start()
    {
        currentClassRoom = classRoomBoard.GetCurrentClassRoom(); // A ClassRoom do ClassRoomBoard é decida no Awake() daquela classe
    }
    public void VerifyAnswer()
    {
        ///Bloquear botão de confirmar
        List<string> respostas = new List<string>();
        List<string> erros;
        bool acertou;
        for (int i = 0; i < classroomAnswers.Count; i++)
        {
            respostas.Add(classroomAnswers[i].GetRespostaAtual());
        }

        (acertou, erros) = currentClassRoom.GetVerification(respostas[0], respostas[1], respostas[2], respostas[3]);

        Debug.Log("Você acertou = " + acertou.ToString());
        foreach (string s in erros)
        {
            Debug.Log("Errou " + s);
        }
    }
}
