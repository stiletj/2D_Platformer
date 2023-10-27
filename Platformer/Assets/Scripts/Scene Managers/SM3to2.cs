using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM3to2 : MonoBehaviour
{
    public string scene;

    private Vector2 momentum;
    public static Vector2 momentumThree;
    public GameObject player;

    PlayerMove playerMove;

    void Start()
    {
        Debug.Log(SM2to3.momentumTwoEnd);
        //sm1to2 = onetotwo.GetComponent<SM1to2>();

        playerMove = player.GetComponent<PlayerMove>();

        playerMove.controller.velocity = SM2to3.momentumTwoEnd;
    }

    void Update()
    {
        momentum = playerMove.controller.velocity;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        momentumThree = momentum;
        //Debug.Log(momentum);

        SceneManager.LoadScene(scene);
    }
}
