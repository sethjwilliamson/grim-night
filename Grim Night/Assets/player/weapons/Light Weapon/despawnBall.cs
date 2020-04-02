using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawnBall : MonoBehaviour
{
    public Light lt;
    public float smooth;
    float timeStamp;
    // Start is called before the first frame update
    void Start()
    {
        timeStamp = Time.time + 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStamp <= Time.time)
            Destroy(gameObject);
        //lt.intensity = Mathf.Lerp(10f, 1f, Time.deltaTime * smooth);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
