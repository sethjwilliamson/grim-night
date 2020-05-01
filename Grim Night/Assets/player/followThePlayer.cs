using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followThePlayer : MonoBehaviour
{
    public CharacterController2D player;
    private void Start()
    {
        player = GameObject.Find("player").GetComponent<CharacterController2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            if(player.isFollowingRoom == true)
                player.isFollowingRoom = false;
            else if (player.isFollowingRoom == false)
                player.isFollowingRoom = true;
            Debug.Log(player.isFollowingRoom);
        }
    }
}
