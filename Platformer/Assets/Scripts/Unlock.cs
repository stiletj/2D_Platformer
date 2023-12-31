using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    public static int doorStatus = 0;

    GameObject player;
    PlayerMove playerMove;    

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
        if (Key.hasKey == true)
        {
            doorStatus = 1;
        }
        else
        {
            doorStatus = 0;
            playerMove.isGrounded = true;
        }
    }

    private IEnumerator OnTriggerExit2D(Collider2D collider)
    {
        playerMove.isGrounded = true;

        yield return new WaitForSeconds(1);

        doorStatus = 0;

        playerMove.isGrounded = true;

        Key.hasKey = false;

        Key.keySprite.enabled = true;

        StartCoroutine(CalmUnlock());
    }

    IEnumerator CalmUnlock()
    {
        Collider2D door;
        door = GetComponent<Collider2D>();

        door.enabled = false;

        yield return new WaitForSeconds(1);

        door.enabled = true;
    }
}
