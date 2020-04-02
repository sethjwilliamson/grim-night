using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponHand : MonoBehaviour
{
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
        leftHand = (gameObject.transform.parent.gameObject == GameObject.Find("bone_6"));
        backgroundHand = GameObject.Find("bone_6");
        foregroundHand = GameObject.Find("bone_9");
        if (leftHand)
        {
            gameObject.transform.parent = backgroundHand.transform;
            gameObject.transform.localPosition = new Vector3(backgroundHandX, backgroundHandY, 0);
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, backgroundRotation);
            sprite.sortingLayerName = "Background";
        }
        else
        {
            gameObject.transform.parent = foregroundHand.transform;
            gameObject.transform.localPosition = new Vector3(foregroundHandX, foregroundHandY, 0);
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, foregroundRotation);
            sprite.sortingLayerName = "Foreground";
        }
    }

    // Update is called once per frame
    void Update()
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
                    sprite.sortingLayerName = "Background";
                }
                if (moveDirection < 0)
                {
                    gameObject.transform.parent = foregroundHand.transform;
                    gameObject.transform.localPosition = new Vector3(foregroundHandX, foregroundHandY, 0);
                    gameObject.transform.localRotation = Quaternion.Euler(0, 0, foregroundRotation);
                    sprite.sortingLayerName = "Foreground";
                }
            }
            else
            {
                if (moveDirection < 0)
                {
                    gameObject.transform.parent = backgroundHand.transform;
                    gameObject.transform.localPosition = new Vector3(backgroundHandX, backgroundHandY, 0);
                    gameObject.transform.localRotation = Quaternion.Euler(0, 0, backgroundRotation);
                    sprite.sortingLayerName = "Background";
                }
                if (moveDirection > 0)
                {
                    gameObject.transform.parent = foregroundHand.transform;
                    gameObject.transform.localPosition = new Vector3(foregroundHandX, foregroundHandY, 0);
                    gameObject.transform.localRotation = Quaternion.Euler(0, 0, foregroundRotation);
                    sprite.sortingLayerName = "Foreground";
                }
            }
        }
    }
}
