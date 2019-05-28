using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(Gamemanager.instance);
        SceneManager.LoadScene("Dungeon");
    }
}
