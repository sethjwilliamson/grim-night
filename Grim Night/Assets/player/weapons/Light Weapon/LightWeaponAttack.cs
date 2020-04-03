using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWeaponAttack : MonoBehaviour
{
    public GameObject ballOfLight;

    Vector2 lookDirection;
    float lookAngle;
    float timeStamp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        if (Input.GetButtonDown("Fire1") && (onCooldown()))
            Shoot();
    }
    void Aim()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);
    }
    void Shoot()
    {
        timeStamp = Time.time + 1;
        GameObject projectile = Instantiate(ballOfLight, gameObject.transform.position, gameObject.transform.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = gameObject.transform.up * 50f;
    }
    bool onCooldown()
    {
        return timeStamp <= Time.time;
    }
}
