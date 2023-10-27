using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateUnlock : MonoBehaviour
{
    public static int doorStatus = 0;

    public bool keyInventory;

    GameObject player;
    PlayerMove playerMove;
    Collider2D m_collider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();
        m_collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        keyInventory = GateKey.hasKey;
        int i = 0;

        foreach (Transform body in transform)
        {
            if (i == doorStatus)
            {
                m_collider.enabled = false;
            }
            else
            {
                m_collider.enabled = true;
            }
            i++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (GateKey.hasKey == true)
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

        GateKey.hasKey = false;

        //GateKey.keySprite.enabled = true;

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
