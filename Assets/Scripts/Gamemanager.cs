using UnityEngine;
using Core.PartySystem;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    [SerializeField]
    PartySystem partySystem;
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

    public PartySystem PartySystem
    {
        get
        {
            return partySystem;
        }
    }
}
