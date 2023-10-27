using UnityEngine;

public class BodyState : MonoBehaviour
{
    public int currentBody = 0;
    GameObject player;
    PlayerMove playerMove;
    Dashing dashing;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();

        dashing = player.GetComponent<Dashing>();

        SelectBody();
    }

    // Update is called once per frame
    void Update()
    {
        int previousCurrentBody = currentBody;

        if (playerMove.movement > 0)
        {
            currentBody = 1;
        }
        else if (playerMove.movement < 0)
        {
            currentBody = 2;
        }

        if (playerMove.movement > 0 && playerMove.isGrounded == false)
        {
            currentBody = 3;
        }
        else if (playerMove.movement < 0 && playerMove.isGrounded == false)
        {
            currentBody = 4;
        }

        if (playerMove.jump == 0 && playerMove.forwardBack == 0)
        {
            currentBody = 0;
        }

        if (dashing.doingDash == true && playerMove.movement >= 0)
        {
            currentBody = 5;
        }

        if (dashing.doingDash == true && playerMove.movement < 0)
        {
            currentBody = 6;
        }

        if (previousCurrentBody != currentBody)
        {
            SelectBody();
        }
    }

    void SelectBody()
    {
        int i = 0;

        foreach (Transform body in transform)
        {
            if (i == currentBody)
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
}
