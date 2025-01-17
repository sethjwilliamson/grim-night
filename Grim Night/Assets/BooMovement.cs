﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooMovement : MonoBehaviour
{
    public CharacterController2D player;
    private float speed = 10.0f;
    private Vector2 target;
    private Vector2 position;

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("player").GetComponent<Transform>().position;
        player = GameObject.Find("player").GetComponent<CharacterController2D>();
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        if(!player.trappedSequence)
            gameObject.transform.position = Vector2.MoveTowards(transform.position, target, step);
    }
}
