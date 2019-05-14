using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core.ControllerSystem;

public class TalkSystem : MonoBehaviour
{
    [SerializeField]
    List<Dialog> dialogs;

    IEnumerator<WaitForSeconds> checkConv;

    public List<Dialog> Dialogs { set => dialogs = value; }

    public IEnumerator<WaitForSeconds> CheckConversation()
    {
        int counter = 0;
        SpeechUI speechUI = Gamemanager.instance.TalkPanel.GetComponent<SpeechUI>();
        speechUI.message = dialogs[0].Lines;

        while (counter < dialogs.Count - 1)
        {
            yield return new WaitForSeconds(0f);
            if (ControllerSystem.Interact)
            {
                counter++;
                speechUI.message = dialogs[counter].Lines;
            }
        }
        Gamemanager.instance.TalkPanel.SetActive(false);
    }
}
