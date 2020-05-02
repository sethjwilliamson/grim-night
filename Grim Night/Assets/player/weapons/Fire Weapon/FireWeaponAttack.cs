using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeaponAttack : MonoBehaviour
{
    public ParticleSystem waterSplash;
    Vector2 lookDirection4;
    Vector2 lookDirection7;
    float lookAngle4;
    float lookAngle7;
    Transform bone4;
    Transform bone7;
    bool leftHand;

    // Start is called before the first frame update
    void Start()
    {
        //waterSplash = GameObject.Find("water").GetComponent<ParticleSystem>();

        bone4 = GameObject.Find("p_bone_4").transform;
        bone7 = GameObject.Find("p_bone_7").transform;
    }

    void LateUpdate()
    {
        Aim();
        if (Input.GetButton("Fire1"))
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
            lookDirection4 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bone4.position;
            lookAngle4 = Mathf.Atan2(lookDirection4.y, lookDirection4.x) * Mathf.Rad2Deg;

            lookDirection7 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bone7.position;
            lookAngle7 = Mathf.Atan2(lookDirection7.y, lookDirection7.x) * Mathf.Rad2Deg;



            bone4.rotation = Quaternion.Euler(0f, 0f, lookAngle4 - 190f);
            bone7.rotation = Quaternion.Euler(0f, 0f, lookAngle7 - 190f);

        }
        else
        {
            lookDirection4 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bone4.position;
            lookAngle4 = Mathf.Atan2(lookDirection4.y, lookDirection4.x) * Mathf.Rad2Deg;

            lookDirection7 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bone7.position;
            lookAngle7 = Mathf.Atan2(lookDirection7.y, lookDirection7.x) * Mathf.Rad2Deg;

            bone7.rotation = Quaternion.Euler(0f, 0f, lookAngle7 - 30f);
            bone4.rotation = Quaternion.Euler(0f, 0f, lookAngle4 - 30f);
        }
    }
}
