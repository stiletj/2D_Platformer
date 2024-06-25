using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool hasKey = false;

    public SpriteRenderer keySprite;

    // Start is called before the first frame update
    void Start()
    {
        keySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("hasKey = " + hasKey);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        hasKey = true;

        Debug.Log("Key Obtained!");

        keySprite.enabled = false;
    }
}
