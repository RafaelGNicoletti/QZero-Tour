using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalk : MonoBehaviour
{
    public string[] falas;
    public TalkTextBox talkTextBox;
    public NPCMovementController controller;

    /// <summary>
    /// Coloca as falas do NPC no balão
    /// </summary>
    public void Talk()
    {
        talkTextBox.ShowTalk(falas);
    }

    public void LookToPlayer(Transform playerPos)
    {
        controller.LookToPlayer(playerPos);
    }
}
