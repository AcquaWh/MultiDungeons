using UnityEngine;
using Core.PartySystem;
using Core.ControllerSystem;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    [SerializeField]
    PartySystem partySystem;
    [SerializeField]
    TalkSystem talkSystem;

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
        talkSystem = GetComponent<TalkSystem>();
    }
    private void Start()
    {
        talkSystem.InitConversation();
        StartCoroutine(talkSystem.CheckConversation());
        talkSystem.CheckConv = talkSystem.CheckConversation();
        StartCoroutine(talkSystem.CheckConv);

    }
    public void InitConversation()
    {
        talkSystem.InitConversation();
    }
    private void Update()
    {
        if (ControllerSystem.Swap) partySystem.SwapLeader();
        if (Input.GetButtonDown("Submit"))
        {
            StopAllCoroutines();
            talkSystem.InitConversation();

        }
    }

    public PartySystem PartySystem
    {
        get
        {
            return partySystem;
        }
    }
}
