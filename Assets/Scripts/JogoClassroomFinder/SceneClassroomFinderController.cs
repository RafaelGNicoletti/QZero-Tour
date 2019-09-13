using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneClassroomFinderController : MonoBehaviour
{
    [SerializeField]
    private List<ClassroomAnswer> classroomAnswers;
    [SerializeField]
    private ClassroomBoard classroomBoard;
    [SerializeField]
    private Classroom currentClassroom;

    private void Start()
    {
        currentClassroom = classroomBoard.GetCurrentClassroom(); // A ClassRoom do ClassRoomBoard é decida no Awake() daquela classe
    }
    public void VerifyAnswer()
    {
        ///Bloquear botão de confirmar
        List<string> respostas = new List<string>(); //Lista de respostas dadas, serão retiradas dos classroomAnswers
        List<string> erros;
        bool acertou;

        for (int i = 0; i < classroomAnswers.Count; i++)
        {
            respostas.Add(classroomAnswers[i].GetRespostaAtual());
        }

        (acertou, erros) = currentClassroom.GetVerification(respostas[0], respostas[1], respostas[2], respostas[3]);

        //Parte de debug, depois alterar para o que será feito com a resposta:
        Debug.Log("Você acertou = " + acertou.ToString());
        foreach (string s in erros)
        {
            Debug.Log("Errou " + s);
        }
    }
}
