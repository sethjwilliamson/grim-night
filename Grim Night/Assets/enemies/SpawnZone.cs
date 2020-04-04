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
    public GameObject enemyPrefab5;
    private GameObject enemy5;
    public Vector3 enemyLocation5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        enemy1 = Instantiate(enemyPrefab1);
        enemy1.transform.position = enemyLocation1;
        enemy2 = Instantiate(enemyPrefab2);
        enemy2.transform.position = enemyLocation2;
        enemy3 = Instantiate(enemyPrefab3);
        enemy3.transform.position = enemyLocation3;
        enemy4 = Instantiate(enemyPrefab4);
        enemy4.transform.position = enemyLocation4;
        enemy5 = Instantiate(enemyPrefab5);
        enemy5.transform.position = enemyLocation5;
    }
}
