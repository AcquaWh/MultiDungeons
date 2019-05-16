using System;
using UnityEngine;
using Core.ControllerSystem;

public abstract class Hero : Player
{
    [SerializeField]
    protected string lore;
    [SerializeField]
    protected bool canMoveAsAllie = false;
    [SerializeField]
    protected bool imLeader = false;
    [SerializeField]
    Transform follow;

    Transform partyLeader;
    
    [SerializeField, Range(0f, 10f)]
    float maxDistanceFollow = 2f;

    [SerializeField, Range(1, 5)]
    float baseDamage;

    private void Start()
    {
        if (inCombat) return;
        partyLeader = Gamemanager.instance.PartySystem.Leader.transform;
        imLeader = this == partyLeader.GetComponent<Hero>();
    }
    protected override void Move()
    {
        if (inCombat) return;
        if (imLeader)
        {
            ControllerSystem.MoveTopDown3D(transform, speed);
        }
        else
        {
            if (follow)
            {
                canMoveAsAllie = Vector3.Distance(transform.position, follow.position) >= maxDistanceFollow;
                if (canMoveAsAllie)
                {
                    transform.LookAt(follow);
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
            }
        }
    }

    protected override void Recover(int health)
    {
        base.Recover(health);
    }

    public bool CanMoveAsAllie
    {
        get => canMoveAsAllie;
    }

    public bool ImLeader
    {
        get => imLeader;
        set => imLeader = value;
    }

    public Transform Follow
    {
        get => follow;
        set => follow = value;
    }

    public float BaseDamage { get => baseDamage; set => baseDamage = value; }
}
