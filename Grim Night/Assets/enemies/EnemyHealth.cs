using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    public float lightEffectiveness;
    public float fireEffectiveness;
    public float waterEffectiveness;
    public float physicalEffectiveness;
    public float rangedEffectiveness;
    private Damage ow;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            ow = other.gameObject.GetComponent<Damage>();
            if (ow.getType() == "Light")
            {
                health = health - (ow.getDamage() * (lightEffectiveness / 100));
            }
            else if (ow.getType() == "Fire")
            {
                health = health - (ow.getDamage() * (fireEffectiveness / 100));
            }
            else if (ow.getType() == "Water")
            {
                health = health - (ow.getDamage() * (waterEffectiveness / 100));
            }
            else if (ow.getType() == "Physical")
            {
                health = health - (ow.getDamage() * (physicalEffectiveness / 100));
            }
            else if (ow.getType() == "Ranged")
            { 
                health = health - (ow.getDamage() * (rangedEffectiveness / 100));
            }
        }

    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("test");
        if (other.gameObject.layer == 8)
        {
            ow = other.gameObject.GetComponent<Damage>();
            if (ow.getType() == "Light")
            {
                health = health - (ow.getDamage() * (lightEffectiveness / 100));
            }
            else if (ow.getType() == "Fire")
            {
                health = health - (ow.getDamage() * (fireEffectiveness / 100));
            }
            else if (ow.getType() == "Water")
            {
                health = health - (ow.getDamage() * (waterEffectiveness / 100));
            }
            else if (ow.getType() == "Physical")
            {
                health = health - (ow.getDamage() * (physicalEffectiveness / 100));
            }
            else if (ow.getType() == "Ranged")
            {
                health = health - (ow.getDamage() * (rangedEffectiveness / 100));
            }
        }
    }
}