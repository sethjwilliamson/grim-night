using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GetLight : MonoBehaviour
{
    public GameObject prefab;
    public GameObject bone6;

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        Instantiate(prefab).transform.SetParent(bone6.transform);
    }
}
