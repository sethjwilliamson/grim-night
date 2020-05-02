using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPlayer : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        player = GameObject.Find("player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.transform.position);
        gameObject.transform.parent = player;
        gameObject.transform.localPosition = new Vector3(0f, 0.2226877f, 0f);
    }
}
