using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWeaponAttack : MonoBehaviour
{
    public ParticleSystem waterSplash;
    Vector2 lookDirection;
    float lookAngle;
    Transform bone4;
    Transform bone7;
    bool leftHand;

    // Start is called before the first frame update
    void Start()
    {
        //waterSplash = GameObject.Find("water").GetComponent<ParticleSystem>();
        bone4 = GameObject.Find("bone_7").transform;
        bone7 = GameObject.Find("bone_4").transform;
    }

    void LateUpdate()
    {
        Aim();
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(waterSplash, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    void Aim()
    {
        if (Input.GetKey(KeyCode.A))
            leftHand = true;
        else if (Input.GetKey(KeyCode.D))
            leftHand = false;

        if (leftHand)
        {
            lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bone4.position;
            lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            bone4.rotation = Quaternion.Euler(0f, 0f, lookAngle - 150f);

        }
        else 
        {
            lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bone7.position;
            lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            bone7.rotation = Quaternion.Euler(0f, 0f, lookAngle - 30f);
        }
    }
}
