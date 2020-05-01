using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponHand : MonoBehaviour
{
    public CharacterController2D player;
    public float backgroundHandX;
    public float backgroundHandY;
    public float backgroundRotation;
    public float foregroundHandX;
    public float foregroundHandY;
    public float foregroundRotation;
    GameObject backgroundHand;
    GameObject foregroundHand;
    SpriteRenderer sprite;
    float moveDirection = 0;
    bool leftHand;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("player").GetComponent<CharacterController2D>();
        leftHand = (gameObject.transform.parent.gameObject == GameObject.Find("bone_6"));
        backgroundHand = GameObject.Find("bone_6");
        foregroundHand = GameObject.Find("bone_9");
        if (leftHand)
        {
            gameObject.transform.parent = backgroundHand.transform;
            gameObject.transform.localPosition = new Vector3(backgroundHandX, backgroundHandY, 0);
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, backgroundRotation);
        }
        else
        {
            gameObject.transform.parent = foregroundHand.transform;
            gameObject.transform.localPosition = new Vector3(foregroundHandX, foregroundHandY, 0);
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, foregroundRotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.napped && !player.trappedSequence)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
                if (leftHand)
                {
                    if (moveDirection > 0)
                    {
                        gameObject.transform.parent = backgroundHand.transform;
                        gameObject.transform.localPosition = new Vector3(backgroundHandX, backgroundHandY, 0);
                        gameObject.transform.localRotation = Quaternion.Euler(0, 0, backgroundRotation);
                        sprite.sortingOrder = 2;
                    }
                    if (moveDirection < 0)
                    {
                        gameObject.transform.parent = foregroundHand.transform;
                        gameObject.transform.localPosition = new Vector3(foregroundHandX, foregroundHandY, 0);
                        gameObject.transform.localRotation = Quaternion.Euler(0, 0, foregroundRotation);
                        sprite.sortingOrder = 9;
                    }
                }
                else
                {
                    if (moveDirection < 0)
                    {
                        gameObject.transform.parent = backgroundHand.transform;
                        gameObject.transform.localPosition = new Vector3(backgroundHandX, backgroundHandY, 0);
                        gameObject.transform.localRotation = Quaternion.Euler(0, 0, backgroundRotation);
                        sprite.sortingOrder = 0;
                    }
                    if (moveDirection > 0)
                    {
                        gameObject.transform.parent = foregroundHand.transform;
                        gameObject.transform.localPosition = new Vector3(foregroundHandX, foregroundHandY, 0);
                        gameObject.transform.localRotation = Quaternion.Euler(0, 0, foregroundRotation);
                        sprite.sortingOrder = 11;
                    }
                }
            }
        }
    }
}
