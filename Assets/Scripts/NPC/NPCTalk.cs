using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalk : MonoBehaviour
{
    public string[] falas;
    public TalkTextBox talkTextBox;

    /// <summary>
    /// Coloca as falas do NPC no balão
    /// </summary>
    public void Talk()
    {
        talkTextBox.ShowTalk(falas);
    }
}
