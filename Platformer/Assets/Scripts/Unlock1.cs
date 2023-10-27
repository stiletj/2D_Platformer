using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock1 : MonoBehaviour
{
    public int doorStatus = 0;

    GameObject player;
    PlayerMove playerMove;

    public GameObject door;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;

        foreach (Transform body in transform)
        {
            if (i == doorStatus)
            {
                body.gameObject.SetActive(true);
            }
            else
            {
                body.gameObject.SetActive(false);
            }
            i++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (Key1.hasKey == true)
        {
            doorStatus = 1;
        }
        else
        {
            doorStatus = 0;
            playerMove.isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        doorStatus = 0;

        playerMove.isGrounded = true;

        Key1.hasKey = false;

        Key1.keySprite.enabled = true;
    }
}
