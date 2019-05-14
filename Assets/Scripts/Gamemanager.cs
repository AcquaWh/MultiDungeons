using UnityEngine;
using Core.PartySystem;
using Core.ControllerSystem;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    [SerializeField]
    PartySystem partySystem;
    [SerializeField]
    GameObject talkPanel;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else if (instance != this)
        {
            Destroy(this);
        }

        partySystem.StartParty();
    }


    private void Update()
    {
        if (ControllerSystem.Swap) partySystem.SwapLeader();
    }

    public PartySystem PartySystem
    {
        get => partySystem;
    }

    public GameObject TalkPanel
    {
        get => talkPanel;
    }
}
