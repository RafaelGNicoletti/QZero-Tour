using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClassroomBoard : MonoBehaviour
{
    [SerializeField]
    private ClassroomGetter classroomGetter;
    [SerializeField]
    private ClassroomCollection salas;
    private int currentClass;
    [SerializeField]
    private TextMeshProUGUI text;

    private void Awake()
    {
        salas = classroomGetter.LoadClassRoom(); //Carrega a lista de salas através do ClassroomGetter
        ChoiceRandomNumber(); //Escolhe uma aleatória
        salas.classRooms[currentClass].FixString(); //Corrige a resposta (explicação disso na função FixString())
    }
        
    private void Start()
    {
        text.text = "Estou procurando a sala <color=#FF0000>" + salas.classRooms[currentClass].codSala.ToString() + "</color>";
    }

    private void ChoiceRandomNumber()
    {
        currentClass = Random.Range(0, salas.classRooms.Count);
    }

    public Classroom GetCurrentClassroom()
    {
        return salas.classRooms[currentClass];
    }

}
