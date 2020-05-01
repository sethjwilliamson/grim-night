using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class warpDoorZone : MonoBehaviour
{
    public string nameOfLevel;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.W))
        {
            SceneManager.LoadScene(nameOfLevel);
        }
    }
}
