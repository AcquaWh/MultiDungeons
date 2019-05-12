using System;
using UnityEngine;
using Core.ControllerSystem;

public class WizardAttack : Wizard
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
            anim.SetTrigger("attack");
        }
    }

}
