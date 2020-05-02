using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GetLight : MonoBehaviour
{
    public GameObject weapon;
    public GameObject weapon2;
    public GameObject bone6;
    public GameObject bone9;

    void OnTriggerEnter2D(Collider2D other)
    {
        foreach (Transform child in bone6.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in bone9.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        weapon.transform.localScale = new Vector3(-1, 1, 1);


        Destroy(GameObject.Find("Examine Light"));
        Destroy(gameObject);
        Instantiate(weapon).transform.SetParent(bone6.transform);

        if (weapon2)
        {
            weapon2.transform.localScale = new Vector3(-1, 1, 1);
            Instantiate(weapon2).transform.SetParent(bone9.transform);
        }
    }
}
