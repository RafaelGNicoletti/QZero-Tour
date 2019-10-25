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
    public virtual void Talk()
    {
        talkTextBox.ShowTalk(falas);
    }

    public virtual void Talk(string [] s)
    {
        talkTextBox.ShowTalk(s);
    }
}
