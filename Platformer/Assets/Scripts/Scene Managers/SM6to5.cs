using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM6to5 : MonoBehaviour
{
    public string scene;

    private Vector2 momentum;
    public static Vector2 momentumSix;
    public GameObject player;

    PlayerMove playerMove;

    void Start()
    {
        Debug.Log(SM5to6.momentumFiveEnd);

        playerMove = player.GetComponent<PlayerMove>();

        playerMove.controller.velocity = SM5to6.momentumFiveEnd;
    }

    void Update()
    {
        momentum = playerMove.controller.velocity;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        momentumSix = momentum;
        //Debug.Log(momentum);

        SceneManager.LoadScene(scene);
    }
}
