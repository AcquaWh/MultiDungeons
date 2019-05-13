using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.ControllerSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    protected int health = 5;
    [SerializeField]
    protected int maxHealth = 10;
    [SerializeField, Range(0f, 10f)]
    protected float speed;

    protected Animator anim;

    public float Speed
    {
        get => speed;
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    protected void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        //ControllerSystem.MoveTopDown3D(transform, speed);
    }
    protected virtual void Recover(int health)
    {
        this.health += this.health + health <= maxHealth ? health : this.health - maxHealth;
    }
}
