using System.Collections.Generic;
using UnityEngine;
using Core.ControllerSystem;
using System;
public class TalkSystem 
{
    [SerializeField]
    List<Dialog> dialogs;

    public List<Dialog> Dialogs { set => dialogs = value; }

    public bool Speaking { get => speaking; set => speaking = value; }
    
    bool speaking = false;
    public IEnumerator<WaitForSeconds> CheckConversation()
    {
        speaking = true;
        int counter = 0;
        SpeechUI speechUI = Gamemanager.instance.TalkPanel.GetComponent<SpeechUI>();
        speechUI.message = dialogs[0].Lines;
        speechUI.profile = dialogs[0].AldeanoImg;
        while (counter <= dialogs.Count - 1)
        {
            yield return new WaitForSeconds(0f);
            if (ControllerSystem.Interact)
            {
                counter++;
                if (counter >= dialogs.Count) break;
                speechUI.message = dialogs[counter].Lines;
                speechUI.profile = dialogs[counter].AldeanoImg;
            }
        }
        Gamemanager.instance.TalkPanel.SetActive(false);
        counter = 0;
        speechUI.message = "";
        speechUI.profile = null;
        Speaking = false;
    }
}
