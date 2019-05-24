using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.ControllerSystem;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{

    private void Update()
    {
        {
            if (ControllerSystem.Attack1)
            {
                SceneManager.LoadScene("Gameplay");
            }
        }
    }
}
