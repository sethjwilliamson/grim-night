using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public string type;
    public float amountOfDamage;
    public string getType()
    {
        return type;
    }
    public float getDamage()
    {
        return amountOfDamage;
    }
}
