using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    private float playerSpeed, tempMov;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ClearSpeed();
        //playerSpeed = player.GetComponent<PlayerMovement>().movementSpeed;
        //player.GetComponent<PlayerMovement>().movementSpeed = 0;
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
}
