using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class examineRoomZone : MonoBehaviour
{
    public CharacterController2D player;
    public Transform paneTo;
    public Transform mainCamera;

    Vector3 paneCamera;
    private void OnTriggerEnter2D(Collider2D other)
    {
        player = GameObject.Find("player").GetComponent<CharacterController2D>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Transform>();
        paneCamera = new Vector3(paneTo.position.x,paneTo.position.y,mainCamera.position.z);
        if (other.gameObject.layer == 9)
        {
            Debug.Log(mainCamera.position);
            player.originalCameraPos = mainCamera.position;
            player.newPos = paneCamera;
            player.trappedSequence = true;
            Destroy(this.gameObject);
        }
    }
}
