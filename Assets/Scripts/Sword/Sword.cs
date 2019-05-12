using System;
using System.Collections.Generic;
using UnityEngine;
using Core.ControllerSystem;

public class Sword : Hero
{
    protected override void Move()
    {
        base.Move();
        if (ImLeader)
        {
            anim.SetFloat("move", Mathf.Abs(ControllerSystem.Axis.magnitude));
        }
    }
    new void Update()
    {
        base.Update();

        if (ControllerSystem.Attack1)
        {
            anim.SetTrigger("attacksword");
        }
    }
}
