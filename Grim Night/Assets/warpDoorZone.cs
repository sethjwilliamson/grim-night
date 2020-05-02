using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class warpDoorZone : MonoBehaviour
{
    public CharacterController2D player;
    public string nameOfLevel;
    private void OnTriggerStay2D(Collider2D other)
    {
        player = GameObject.Find("player").GetComponent<CharacterController2D>();
        if (Input.GetKey(KeyCode.W))
        {
            SceneManager.LoadScene(nameOfLevel);
            if(nameOfLevel == "level 4")
            {
                player.finalBoss = true;
            }
        }
    }
}
