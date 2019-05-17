using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.ControllerSystem;
using UnityEngine.SceneManagement;


public class CombatSystem : MonoBehaviour
{
    [SerializeField]
    StatsPanel statspanel;

    [SerializeField]
    List<GameObject> turns;

    [SerializeField]
    Transform spawnPoint;

    IEnumerator<WaitForSeconds> checkCombat;

    private void Start()
    {
        Gamemanager.instance.Enemie4Combat.transform.parent = null;
        Gamemanager.instance.Enemie4Combat.transform.position = spawnPoint.position;
        Hero[] heroes = GameObject.FindObjectsOfType<Hero>();

        foreach (Hero h in heroes)
        {
            turns.Add(h.gameObject);
        }

        Enemies[] enemines = GameObject.FindObjectsOfType<Enemies>();

        foreach(Enemies e in enemines)
        {
            turns.Add(e.gameObject);
        }

        Gamemanager.instance.Enemie4Combat.transform.LookAt(turns[0].transform);

        checkCombat = CheckCombat();
        StartCoroutine(checkCombat);

    }

    public IEnumerator<WaitForSeconds> CheckCombat()
    {
        int turnIndex = 0;
        Enemies enemy = Gamemanager.instance.Enemie4Combat.GetComponent<Enemies>();
        while (!statspanel.imDead || enemy.CurrentHealth == 0f)
        {
            Debug.Log("hello");
            yield return new WaitForSeconds(0f);
            if (ControllerSystem.Attack1)
            {
                
                GameObject currentTurn = turns[turnIndex];

                if (currentTurn.GetComponent<Hero>())
                {
                    Debug.Log("hero attack");
                    Hero hero = currentTurn.GetComponent<Hero>();
                    statspanel.GetName(hero.BaseName);
                    enemy.GetDamage(hero.BaseDamage);


                }
                if (currentTurn.GetComponent<Enemies>())
                {
                    Debug.Log("enemy attack");
                    
                    statspanel.GetName(enemy.BaseName);
                    statspanel.GetDamage(enemy.BaseDamage);
                    if (statspanel.imDead)
                    {
                        SceneManager.LoadScene("GameOver");
                        Debug.Log("Muerto");
                    }
                    if (enemy.CurrentHealth == 0f)
                    {
                   
                        
                        Debug.Log("Muerto malvado");
                    }
                }
                if (turnIndex < turns.Count - 1)
                {
                    turnIndex++;

                }
                else if(!statspanel.imDead || enemy.CurrentHealth == 0f)
                {
                    turnIndex = 0;
                } 
            }
        }

    }
    
}


