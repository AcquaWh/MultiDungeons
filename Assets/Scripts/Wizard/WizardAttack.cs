﻿using System;
using UnityEngine;
using Core.ControllerSystem;

public class WizardAttack : Wizard
{

    protected override void Move()
    {
        if (inCombat) return;
        base.Move();
        if (ImLeader)
        {
            anim.SetFloat("move", Mathf.Abs(ControllerSystem.Axis.magnitude));
        }
        else
        {
            anim.SetFloat("move", canMoveAsAllie ? 1 : 0);
        }
    }
    new void Update()
    {
        if (inCombat) return;
        base.Update();

        if (ControllerSystem.Attack1)
        {
            anim.SetTrigger("attack");
        }
    }

}
