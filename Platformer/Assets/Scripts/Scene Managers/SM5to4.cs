using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM5to4 : MonoBehaviour
{
    public string scene;

    private Vector2 momentum;
    public static Vector2 momentumFive;
    public GameObject player;

    PlayerMove playerMove;

    void Start()
    {
        Debug.Log(SM4to5.momentumFourEnd);

        playerMove = player.GetComponent<PlayerMove>();

        playerMove.controller.velocity = SM4to5.momentumFourEnd;
    }

    void Update()
    {
        momentum = playerMove.controller.velocity;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        momentumFive = momentum;
        //Debug.Log(momentum);

        SceneManager.LoadScene(scene);
    }
}
