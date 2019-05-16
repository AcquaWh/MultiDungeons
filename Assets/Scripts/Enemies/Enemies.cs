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

    public float CurrentHealth { get => currentHealth;}
    public float BaseDamage { get => baseDamage; set => baseDamage = value; }

    private void OnTriggerEnter(Collider other)
    {
        Gamemanager.instance.Enemie4Combat = gameObject;
        gameObject.transform.parent = Gamemanager.instance.transform;
        SceneManager.LoadScene("BattleScene");
    }

    public void GetDamage(float damage)
    {
        currentHealth -= currentHealth - damage > 0 ? damage : currentHealth;
    }
}
