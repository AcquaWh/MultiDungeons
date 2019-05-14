using System;
using System.Collections.Generic;
using UnityEngine;
using Core.ControllerSystem;

public class NPC : MonoBehaviour
{
    [SerializeField]
    List<Dialog> lines;

    public List<Dialog> Lines { get => lines; }

    TalkSystem talkSystem;

    IEnumerator<WaitForSeconds> checkConv;


    private void Awake()
    {
        talkSystem = new TalkSystem();
    }

    private void Start()
    {
        checkConv = talkSystem.CheckConversation();
    }

    //Talking
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Hero hero = other.GetComponent<Hero>();
            if (hero.ImLeader && ControllerSystem.Interact)
            {
                if (!Gamemanager.instance.TalkPanel.activeSelf)
                {
                    Gamemanager.instance.TalkPanel.SetActive(true);
                    talkSystem.Dialogs = lines;
                    StartCoroutine(checkConv);
                }
            }
        }
    }
}

