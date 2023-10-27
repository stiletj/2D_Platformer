using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM2to1 : MonoBehaviour
{
    public string scene;

    private Vector2 momentum;
    public static Vector2 momentumTwo;
    public GameObject player;

    PlayerMove playerMove;

    void Start()
    {
        //sm1to2 = onetotwo.GetComponent<SM1to2>();

        playerMove = player.GetComponent<PlayerMove>();

        playerMove.controller.velocity = SM1to2.momentumOneEnd;
    }

    void Update()
    {
        momentum = playerMove.controller.velocity;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        momentumTwo = momentum;
        //Debug.Log(momentum);

        SceneManager.LoadScene(scene);
    }
}
