using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClassRoomBoard : MonoBehaviour
{
    public ClassRoomGetter classRoomGetter;
    [SerializeField]
    private ClassRoomCollection salas;
    private int currentClass;
    public TextMeshProUGUI text;

    private void Awake()
    {
        salas = classRoomGetter.LoadClassRoom();
        ChoiceRandomNumber();
    }
        
    private void Start()
    {
        text.text = "Estou procurando a sala <color=#FF0000>" + salas.classRooms[currentClass].codSala.ToString() + "</color>";
    }
    private void ChoiceRandomNumber()
    {
        currentClass = Random.Range(0, salas.classRooms.Count);
    }

    public ClassRoom GetCurrentClassRoom()
    {
        return salas.classRooms[currentClass];
    }

}
