using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public Text Changingtext;
    GameObject player;

    Dashing dashing;
    PlayerMove playerMove;
    float speedo = 0f;

    // Start is called before the first frame update
    void Start()
    {
        dashing = ManageScenes.player.GetComponent<Dashing>();

        playerMove = ManageScenes.player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        speedo = playerMove.controller.velocity.x;

        Changingtext.text = "Dash: " + dashing.dashTimer.ToString("n2") + " s" + "\n\nSpeed: " + /*playerMove.controller.velocity*/ speedo.ToString("n1") + " m/s";
    }
}
