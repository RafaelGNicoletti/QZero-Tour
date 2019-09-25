using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    private float playerSpeed, tempMov;
    private GameObject player;

    private void Start()
    {
        if (!GameManager.instance.tutorialViewed)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            ClearSpeed();
            GameObject.Find("Canvas").GetComponent<Animator>().SetBool("FirstTime", true);
            GameManager.instance.tutorialViewed = true;
        } else
        {
            GameObject.Find("Canvas").GetComponent<Animator>().SetBool("Tutorial", false);
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
        this.GetComponent<Animator>().SetTrigger(trigger);
    }

    public void SetBoolTrue(string boolName)
    {
        this.GetComponent<Animator>().SetBool(boolName, true);
    }

    public void SetBoolFalse(string boolName)
    {
        this.GetComponent<Animator>().SetBool(boolName, false);
    }
}
