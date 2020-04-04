using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GetLight : MonoBehaviour
{
    public GameObject prefab;
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

        Destroy(gameObject);
        Instantiate(prefab).transform.SetParent(bone6.transform);
    }
}
