using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWeaponAttack : MonoBehaviour
{
    public CharacterController2D player;
    public GameObject ballOfLight;
    Animator animator;
    Vector2 lookDirection;
    float lookAngle;
    float timeStamp;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").GetComponent<CharacterController2D>();
        animator = GameObject.Find("sprite").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.trappedSequence) {
            Aim();
            if (Input.GetButtonDown("Fire1") && (onCooldown())) {
                Animate();
                StartCoroutine(Wait());
                Shoot();
            }
        }
    }
    void Aim()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);
    }
    void Shoot()
    {
        timeStamp = Time.time + .5f;
        GameObject projectile = Instantiate(ballOfLight, gameObject.transform.position, gameObject.transform.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = gameObject.transform.up * 50f;
    }
    bool onCooldown()
    {
        return timeStamp <= Time.time;
    }

    void Animate()
    {
      
            animator.SetTrigger("Attack1");
        
        
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f); 
    }
}
