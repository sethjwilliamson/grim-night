using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterRoom : MonoBehaviour
{
    public CharacterController2D player;
    public float newCameraSize;

    Vector3 paneCamera;
    private void OnTriggerEnter2D(Collider2D other)
    {
        player = GameObject.Find("player").GetComponent<CharacterController2D>();
        if (other.gameObject.layer == 9)
        {
            player.enteredRoom = true;
            player.cameraSize = newCameraSize;
        }
    }
}
