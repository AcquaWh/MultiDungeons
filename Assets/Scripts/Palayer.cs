using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.ControllerSystem;

public class Palayer : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)]
    float speed;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        ControllerSystem.MoveTopDown3D(transform, speed);
        anim.SetFloat("move", Mathf.Abs(ControllerSystem.Axis.magnitude));
    }
}
