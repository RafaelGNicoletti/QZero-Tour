using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private float playerSpeed, tempMov;
    private GameObject player;
    public GameObject canvas;
    public GameObject camera;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (!GameManager.instance.tutorialViewed)
        {
            ClearSpeed();
            GameObject.Find("Canvas").GetComponent<Animator>().SetBool("FirstTime", true);
            GameManager.instance.tutorialViewed = true;

            GameManager.instance.SetPlayerPos(player.transform.position);
            GameManager.instance.SetCameraPos(camera.transform.position);
        }
        else
        {
            GameObject.Find("Canvas").GetComponent<Animator>().SetBool("Tutorial", false);

            player.transform.position = GameManager.instance.GetPlayerPos();
            camera.transform.position = GameManager.instance.GetCameraPos();
        }
    }

    public void ClearSpeed()
    {
        playerSpeed = player.GetComponent<PlayerMovement>().movementSpeed;
        player.GetComponent<PlayerMovement>().movementSpeed = 0;
    }

    public void RestoreSpeed()
    {
        player.GetComponent<PlayerMovement>().movementSpeed = playerSpeed;
    }

    public void Toggle(GameObject target)
    {
        target.SetActive(!target.active);
    }

    public void SetAnimationTrigger(string trigger)
    {
        canvas.GetComponent<Animator>().SetTrigger(trigger);
    }

    public void SetBoolTrue(string boolName)
    {
        canvas.GetComponent<Animator>().SetBool(boolName, true);
    }

    public void SetBoolFalse(string boolName)
    {
        canvas.GetComponent<Animator>().SetBool(boolName, false);
    }
}
