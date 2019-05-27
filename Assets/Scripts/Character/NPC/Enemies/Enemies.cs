using System.Collections.Generic;
using UnityEngine;
using Core.ControllerSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemies : MonoBehaviour
{

    [SerializeField, Range(0f, 5f)]
    float baseDamage;
    [SerializeField]
    string baseName;

    [SerializeField]
    bool used = false;



    public float BaseDamage { get => baseDamage; set => baseDamage = value; }
    public string BaseName { get => baseName; set => baseName = value; }
   


    private void OnTriggerEnter(Collider other)
    {
        Gamemanager.instance.Enemie4Combat = gameObject;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("BattleScene");
    }

}
