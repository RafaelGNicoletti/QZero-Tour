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
    [SerializeField]
    private ClassroomResultManager classroomResultManager;

    private void Start()
    {
        currentClassroom = classroomBoard.GetCurrentClassroom(); // A ClassRoom do ClassRoomBoard é decida no Awake() daquela classe
    }
    public void VerifyAnswer()
    {
        List<string> respostas = new List<string>(); //Lista de respostas dadas, serão retiradas dos classroomAnswers
        List<string> erros;
        bool acertou;

        for (int i = 0; i < classroomAnswers.Count; i++)
        {
            respostas.Add(classroomAnswers[i].GetRespostaAtual());
        }

        (acertou, erros) = currentClassroom.GetVerification(respostas[0], respostas[1], respostas[2], respostas[3]);

        classroomResultManager.ShowResult(acertou, erros);
    }
}
