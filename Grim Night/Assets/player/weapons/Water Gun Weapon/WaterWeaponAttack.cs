using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWeaponAttack : MonoBehaviour
{
    public ParticleSystem waterSplash;
    
    // Start is called before the first frame update
    void Start()
    {
        //waterSplash = GameObject.Find("water").GetComponent<ParticleSystem>();
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(waterSplash, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
