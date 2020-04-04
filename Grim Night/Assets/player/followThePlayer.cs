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
            Debug.Log("isInTheRoom");
            player.isFollowingRoom = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            Debug.Log("LeftTheRoom");
            player.isFollowingRoom = true;
        }
    }
}
