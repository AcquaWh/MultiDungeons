using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Core.EnemySystem
{
    [Serializable]
    public class EnemySystem
    {
        [SerializeField]
        List<string> enemiesInGame;

        [SerializeField]
        List<string> deadEnemiesList;

        public List<string> DeadEnemiesList { get => deadEnemiesList; set => deadEnemiesList = value; }
        public List<string> EnemiesInGame { get => enemiesInGame; set => enemiesInGame = value; }

        public void InitEnemyList()
        {
            Enemies[] enemines = GameObject.FindObjectsOfType<Enemies>();
            foreach (Enemies e in enemines)
            {
                enemiesInGame.Add(e.gameObject.name);
            }
        }
        
        public void Check4DeadEnemies()
        {
            deadEnemiesList.Clear();

            Enemies[] enemines = GameObject.FindObjectsOfType<Enemies>();
            foreach (Enemies e in enemines)
            {
                deadEnemiesList.Add(e.gameObject.name);
            }

            foreach (Enemies e in enemines)
            {
                foreach(string s in enemiesInGame)
                {
                    if(e.name == s)
                    {
                        deadEnemiesList.Remove(s);
                    }  
                }
            }
        }
    }
}
