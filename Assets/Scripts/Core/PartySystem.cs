using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.PartySystem
{
    [Serializable]
    public class PartySystem
    {
        [SerializeField]
        List<Hero> party = new List<Hero>();

        [SerializeField]
        Hero leader;

        public List<Hero> Party
        {
            get => party;
        }

        public Hero Leader
        {
            get => leader;
        }

        public void StartParty()
        {
            Hero[] heroes = GameObject.FindObjectsOfType<Hero>();

            foreach (Hero hero in heroes)
            {
                if (hero.ImLeader) party.Add(hero);
            }

            foreach (Hero hero in heroes)
            {
                if(!hero.ImLeader) party.Add(hero);
            }

            leader = party[0];

            for(int i = 0; i < party.Count; i++)
            {
                Hero hero = party[i];
                if (!hero.ImLeader) hero.Follow = party[i - 1].transform;
            }
        }
    }
}
