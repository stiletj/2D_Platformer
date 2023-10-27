using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1 : MonoBehaviour
{
    public static bool hasKey = false;

    public static SpriteRenderer keySprite;

    // Start is called before the first frame update
    void Start()
    {
        keySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        hasKey = true;

        keySprite.enabled = false;
    }
}
