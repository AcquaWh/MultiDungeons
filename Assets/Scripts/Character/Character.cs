using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.ControllerSystem;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    protected int health = 5;
    [SerializeField]
    protected int maxHealth = 10;
    [SerializeField, Range(0f, 10f)]
    protected float speed;
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
    [SerializeField]
    string baseName;
    protected Animator anim;

    [SerializeField]
    protected bool inCombat = false;


    public float Speed
    {
        get => speed;
    }

    private void Start()
    {
        if (inCombat) return;
        partyLeader = Gamemanager.instance.PartySystem.Leader.transform;
        imLeader = this == partyLeader.GetComponent<Hero>();
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    protected void Update()
    {
        Move();
        Attack();
    }

    protected virtual void Move()
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
    protected virtual void Attack()
    {
        if (inCombat)
        {
            if (ControllerSystem.Attack1)
            {
                anim.SetBool("attack", true);
            }
            else
            {
                anim.SetBool("attack", false);
            }
        }
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

    protected virtual void Recover(int health)
    {
        this.health += this.health + health <= maxHealth ? health : this.health - maxHealth;
    }

    public float BaseDamage { get => baseDamage; set => baseDamage = value; }
    public string BaseName { get => baseName; set => baseName = value; }
}
