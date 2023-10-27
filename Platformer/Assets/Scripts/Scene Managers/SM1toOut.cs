using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM1toOut : MonoBehaviour
{
    public string scene;

    private Vector2 momentum;
    public static Vector2 momentumOne;
    public GameObject player;

    PlayerMove playerMove;

    void Start()
    {
        playerMove = player.GetComponent<PlayerMove>();

        playerMove.controller.velocity = SMOutto1.momentumOutside;
    }

    void Update()
    {
        momentum = playerMove.controller.velocity;

        //Debug.Log(momentum);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        momentumOne = momentum;
        //Debug.Log(momentum);

        SceneManager.LoadScene(scene);
    }
}
