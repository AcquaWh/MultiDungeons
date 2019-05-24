using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanel : MonoBehaviour
{
    [SerializeField]
    Text txtName;

    [SerializeField]
    Slider sld_currenthealth;

    [SerializeField]
    Slider sld_currenthealthenemie;

    public string PlayerName { set => txtName.text = value; get => txtName.text; }
    public float PlayerCurrentHealth { set => sld_currenthealth.value = value; get => sld_currenthealth.value; }
    public float EnemieCurrentHealth { set => sld_currenthealthenemie.value = value; get => sld_currenthealthenemie.value; }

    public void GetDamage(float damage)
    {
        sld_currenthealth.value -= damage;
    }
    public void GetDamagevalue(float damage)
    {
        sld_currenthealthenemie.value -= damage;
    }

    public void GetName(string name)
    {
       txtName.text = name;
    }


    public bool imDead { get => sld_currenthealth.value == 0f; }

}
