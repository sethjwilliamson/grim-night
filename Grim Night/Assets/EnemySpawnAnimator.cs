using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnAnimator : MonoBehaviour
{
    public Animator swirl;
    public SpriteRenderer swirlSprite;
    // Start is called before the first frame update
    void Start()
    {
        swirl.enabled = false;
        swirlSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
