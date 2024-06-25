using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int doorStatus = 0;

    GameObject player;
    PlayerMove playerMove;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMove = ManageScenes.player.GetComponent<PlayerMove>();
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
        doorStatus = 1;

        Debug.Log("Open");
    }

    private IEnumerator OnTriggerExit2D(Collider2D collider)
    {
        playerMove.isGrounded = true;

        yield return new WaitForSeconds(1);

        doorStatus = 0;

        Debug.Log("Close");

        StartCoroutine(Calm());
    }

    IEnumerator Calm()
    {
        Collider2D door;
        door = GetComponent<Collider2D>();

        door.enabled = false;

        yield return new WaitForSeconds(1);

        door.enabled = true;
    }
}

/* Trigger is entered and exited almost immediately so can't go through door. */
