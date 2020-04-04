using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GetLight : MonoBehaviour
{
    public GameObject wandPrefab;
    private GameObject wand;

    public GameObject bone6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        Debug.Log("TEST");
        wand = Instantiate(wandPrefab);
        wand.transform.SetParent(bone6.transform);
    }
}
