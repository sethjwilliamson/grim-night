using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNapped : MonoBehaviour
{
    public float health = 100;
    public float lightEffectiveness;
    public float fireEffectiveness;
    public float waterEffectiveness;
    public float physicalEffectiveness;
    public float rangedEffectiveness;
    private GameObject nabbed;
    private bool phaseOne;
    private bool phaseTwo;
    private bool phaseThree;
    private bool phaseFour;
    private Vector3 startPos;
    public Vector3 checkPoint;
    private void Start()
    {
        startPos = transform.root.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        nabbed = other.gameObject;
        nabbed.transform.parent = gameObject.transform;
        StartCoroutine(Teleport());
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
            nabbed.transform.localPosition = new Vector3(2f, 13f, 0);
            nabbed.transform.localRotation = Quaternion.Euler(0, 0, 90f);
            phaseOne = false;
        }
        if (phaseThree)
        {
            transform.root.position = startPos;
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
