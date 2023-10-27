using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SMOutto1 : MonoBehaviour
{
    public string scene;

    private Vector2 momentum;
    public static Vector2 momentumOutside;
    public GameObject player;
    PlayerMove playerMove;

    void Start()
    {
        playerMove = player.GetComponent<PlayerMove>();

        playerMove.controller.velocity = SM1toOut.momentumOne;
    }

    void Update()
    {
        momentum = playerMove.controller.velocity;

        //Debug.Log(momentum);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        momentumOutside = momentum;
        //Debug.Log("momentumOutside" + momentumOutside);

        SceneManager.LoadScene(scene);
    }
}
