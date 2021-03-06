﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe que contém as reações de objetos com o qual o player pode interagir
/// </summary>
public class InteractableObject : MonoBehaviour
{
    public string sceneName;
    public Vector3 newScenePlayerPos;

    private GameObject player;
    private GameObject camera;

    [SerializeField] private bool talkTo;
    [SerializeField] private bool enterBuilding;
    [SerializeField] private bool enterGame;

    [SerializeField] private bool elevator;
    [SerializeField] private bool fretado;
    
    [SerializeField] private GameObject objectToTalk;
    [SerializeField] private GameObject elevatorWindow;

    #region Get/Set
    public bool GetTalkTo()
    {
        return talkTo;
    }

    public bool GetEnterBuilding()
    {
        return enterBuilding;
    }

    public bool GetEnterGame()
    {
        return enterGame;
    }

    public bool GetElevator()
    {
        return elevator;
    }
    #endregion

    public void LoadMinigame()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.Find("Main Camera");
        GameManager.instance.SetPlayerPos(player.transform.position);
        GameManager.instance.SetCameraPos(camera.transform.position);

        GameManager.instance.SetLastSceneName(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

        SceneManager.LoadScene(sceneName);
    }

    public void LoadMap()
    {
        GameManager.instance.SetPlayerPos(newScenePlayerPos);
        GameManager.instance.SetCameraPos(new Vector3 (newScenePlayerPos.x, newScenePlayerPos.y, newScenePlayerPos.z-10));

        SceneManager.LoadScene(sceneName);
    }

    public void PlayDialogue()
    {
        //if (objectToTalk.GetComponent<NPCTalk>())
        //{

        //}
        //else 
        if (objectToTalk.GetComponent<AuxiliosManager>())
        {
            objectToTalk.GetComponent<AuxiliosManager>().StartAuxilioMinigame();
        }
    }

    public void OpenElevator()
    {
        MapController.instance.OpenElevador(elevatorWindow);
    }


}
