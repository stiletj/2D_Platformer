using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    public int doorStatus = 0;

    public GameObject keyOBJ;

    PlayerMove playerMove;
    Key keyScript;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = ManageScenes.player.GetComponent<PlayerMove>();
        keyScript = keyOBJ.GetComponent<Key>();
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
                //Debug.Log("off");
            }
            i++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (keyScript.hasKey)
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

        keyScript.hasKey = false;

        keyScript.keySprite.enabled = true;

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
