using System.Collections.Generic;
using UnityEngine;
using Core.ControllerSystem;
using UnityEngine.SceneManagement;

public class Enemies : MonoBehaviour
{
    [SerializeField]
    float currentHealth;

    [SerializeField, Range(0f, 5f)]
    float baseDamage;
    [SerializeField]
    string baseName;

    [SerializeField]
    bool used = false;

    public float CurrentHealth { get => currentHealth;}
    public float BaseDamage { get => baseDamage; set => baseDamage = value; }
    public string BaseName { get => baseName; set => baseName = value; }


    private void OnTriggerEnter(Collider other)
    {
        Gamemanager.instance.Enemie4Combat = gameObject;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("BattleScene");
    }

    public void GetDamage(float damage)
    {
        currentHealth -= currentHealth - damage > 0 ? damage : currentHealth;
    }
}
