using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transport : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Gamemanager.instance.Enemie4Combat = gameObject;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("GameOver");
    }
}
