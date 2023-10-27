using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateKey : MonoBehaviour
{
    public static bool hasKey = false;

    public static SpriteRenderer keySprite;

    public Collider2D keyColl;

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

        Debug.Log("Key Obtained!");

        keySprite.enabled = false;
        keyColl.enabled = false;
    }
}
