using UnityEngine;
using Core.PartySystem;
using Core.ControllerSystem;
using Core.EnemySystem;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    [SerializeField]
    PartySystem partySystem;
    [SerializeField]
    GameObject talkPanel;

    [SerializeField]
    GameObject enemie4Combat;

    [SerializeField]
    string enemy4Delete = null;

    [SerializeField]
    EnemySystem enemySystem;

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
        enemySystem.InitEnemyList();
    }

    void ClearDeadenemies()
    {
        enemySystem.Check4DeadEnemies();
        foreach (string s in enemySystem.DeadEnemiesList)
        {
            GameObject deadEnemy = GameObject.Find(s);
            Destroy(deadEnemy);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        switch (level)
        {
            case 1:
                partySystem.StartParty();
                ClearDeadenemies();
                break;
        }
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
    public string Enemy4Delete { get => enemy4Delete; set => enemy4Delete = value; }
    public EnemySystem EnemySystem { get => enemySystem; set => enemySystem = value; }
}
