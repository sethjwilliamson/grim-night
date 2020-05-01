using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNapped : MonoBehaviour
{
    private GameObject nabbed;
    private bool phaseOne;
    private bool phaseTwo;
    private bool phaseThree;
    private Vector3 startPos;
    private Quaternion startRot;
    public Vector3 checkPoint;
    private void Start()
    {
        startPos = transform.root.position;
        startRot = transform.root.rotation;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            nabbed = other.gameObject;
            nabbed.transform.parent = gameObject.transform;
            StartCoroutine(Teleport());
        }
    }
    private void Update()
    {
        if (phaseOne)
        {
            nabbed.transform.localPosition = new Vector3(2f, 13f, 0);
            nabbed.transform.localRotation = Quaternion.Euler(0, 0, 90f);
            phaseThree = false;
        }
        if (phaseTwo)
        {
            transform.root.position = checkPoint;
            transform.root.rotation = Quaternion.Euler(0, 0, 0f);
            nabbed.transform.localPosition = new Vector3(2f, 13f, 0);
            nabbed.transform.localRotation = Quaternion.Euler(0, 0, 90f);
            phaseOne = false;
        }
        if (phaseThree)
        {
            transform.root.position = startPos;
            transform.root.rotation = startRot;
            phaseTwo = false;
        }
    }
    public IEnumerator Teleport()
    {
        phaseOne = true;
        yield return new WaitForSeconds(1f);
        phaseTwo = true;
        yield return new WaitForSeconds(1f);
        DropEm();
        yield return new WaitForSeconds(1f);
        phaseThree = true;
    }
    public void DropEm()
    {
        nabbed.transform.localRotation = Quaternion.Euler(0, 0, 0);
        nabbed.transform.parent = null;
        nabbed = null;
        phaseTwo = false;
    }
}
