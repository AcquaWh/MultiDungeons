using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkSystem : MonoBehaviour
{
    IEnumerator<WaitForSeconds> checkConv;
    [SerializeField]
    GameObject talkSystemUI;
    [SerializeField]
    Text textMessage;
    [SerializeField]
    string message = "";

    public IEnumerator<WaitForSeconds> CheckConv { get => checkConv; set => checkConv = value; }

    private void Start()
    {
        checkConv = CheckConversation();
        StartCoroutine(checkConv);
        InitConversation();
    }


    public void InitConversation()
    {
        StartCoroutine(checkConv);
    }

    public IEnumerator<WaitForSeconds> CheckConversation()
    {
        talkSystemUI.SetActive(true);
        textMessage.text = message;
        while (true)
        {
            yield return new WaitForSeconds(3f);
            if (!talkSystemUI.activeSelf)
            {
                talkSystemUI.SetActive(true);
            }
        }
    }
}
