using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.ControllerSystem
{
    public class ControllerSystem
    {
        public static Vector3 Axis
        {
            get => new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        }

        public static Vector3 AxisDelta
        {
            get => new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * Time.deltaTime;
        }

        public static void MoveTopDown3D(Transform t, float speed)
        {
            t.Translate(Vector3.forward * AxisDelta.magnitude * speed);
            if(isMoving)
            {
                t.rotation = Quaternion.LookRotation(Axis);
            }
        }

        public static bool isMoving
        {
            get => Axis != Vector3.zero;
        }

        public static bool Attack1
        {
            get => Input.GetButtonDown("Fire1");
        }

        public static bool Swap
        {
            get => Input.GetButtonDown("swap");
        }

        public static bool Interact
        {
            get => Input.GetButtonDown("Submit");
        }
    }
}
