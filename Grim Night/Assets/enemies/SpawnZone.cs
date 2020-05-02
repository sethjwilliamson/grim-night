using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public GameObject enemyPrefab1;
    private GameObject enemy1;
    public Vector3 enemyLocation1;
    public GameObject enemyPrefab2;
    private GameObject enemy2;
    public Vector3 enemyLocation2;
    public GameObject enemyPrefab3;
    private GameObject enemy3;
    public Vector3 enemyLocation3;
    public GameObject enemyPrefab4;
    private GameObject enemy4;
    public Vector3 enemyLocation4;

    public CharacterController2D player;
    public Transform paneTo;
    public Transform mainCamera;

    Vector3 paneCamera;
    bool plsno;

    void OnTriggerEnter2D(Collider2D other)
    {
        player = GameObject.Find("player").GetComponent<CharacterController2D>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Transform>();
        paneCamera = new Vector3(paneTo.position.x, paneTo.position.y, mainCamera.position.z);
        if (other.gameObject.layer == 9 && !plsno)
        {
            player.originalCameraPos = mainCamera.position;
            player.newPos = paneCamera;
            player.trappedSequence = true;
            enemy1 = Instantiate(enemyPrefab1);
            enemy1.transform.parent = this.gameObject.transform;
            enemy1.transform.localPosition = enemyLocation1;
            enemy2 = Instantiate(enemyPrefab2);
            enemy2.transform.parent = this.gameObject.transform;
            enemy2.transform.localPosition = enemyLocation2;
            enemy3 = Instantiate(enemyPrefab3);
            enemy3.transform.parent = this.gameObject.transform;
            enemy3.transform.localPosition = enemyLocation3;
            enemy4 = Instantiate(enemyPrefab4);
            enemy4.transform.parent = this.gameObject.transform;
            enemy4.transform.localPosition = enemyLocation4;
            plsno = true;
        }
        if(!player.trappedSequence && plsno)
            Destroy(this.gameObject.GetComponent<SpawnZone>());
    }
}
