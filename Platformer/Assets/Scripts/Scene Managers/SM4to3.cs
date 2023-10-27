using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM4to3 : MonoBehaviour
{
    public string scene;

    private Vector2 momentum;
    public static Vector2 momentumFour;
    public GameObject player;

    PlayerMove playerMove;

    void Start()
    {
        //sm1to2 = onetotwo.GetComponent<SM1to2>();

        playerMove = player.GetComponent<PlayerMove>();

        playerMove.controller.velocity = SM3to4.momentumThreeEnd;
    }

    void Update()
    {
        momentum = playerMove.controller.velocity;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        momentumFour = momentum;
        //Debug.Log(momentum);

        SceneManager.LoadScene(scene);
    }
}
