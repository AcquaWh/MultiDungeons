using System;
using UnityEngine;
using Core.ControllerSystem;

public abstract class Hero : Player
{
    [SerializeField]
    protected string lore;
    [SerializeField]
    private bool canMoveAsAllie = false;
    [SerializeField]
    private bool imLeader = false;

    Transform partyLeader;
    
    [SerializeField, Range(0f, 10f)]
    float maxDistanceFollow = 2f;

    private void Start()
    {
        partyLeader = Gamemanager.instance.PartySystem.Leader.transform;
        imLeader = this == partyLeader.GetComponent<Hero>();
    }
    protected override void Move()
    {
        if (imLeader)
        {
            transform.Translate(Vector3.forward * ControllerSystem.Axis.magnitude * speed * Time.deltaTime);

            if (ControllerSystem.Axis != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(ControllerSystem.Axis);
            }
        }
        else
        {
            canMoveAsAllie = Vector3.Distance(transform.position, partyLeader.position) >= maxDistanceFollow;
            if (canMoveAsAllie)
            {
                transform.LookAt(partyLeader);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                anim.SetFloat("move", Mathf.Abs(ControllerSystem.Axis.magnitude));
            }
        }
    }

    protected override void Recover(int health)
    {
        base.Recover(health);
    }


    public bool CanMoveAsAllie
    {
        get
        {
            return canMoveAsAllie;
        }
    }

    public bool ImLeader
    {
        get
        {
            return imLeader;
        }
    }
}
