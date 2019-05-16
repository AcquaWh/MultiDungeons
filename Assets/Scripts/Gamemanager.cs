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

    [SerializeField]
    GameObject enemie4Combat;

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
    public GameObject Enemie4Combat { get => enemie4Combat; set => enemie4Combat = value; }
}
