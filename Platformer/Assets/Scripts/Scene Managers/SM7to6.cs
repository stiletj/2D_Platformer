using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM7to6 : MonoBehaviour
{
    public string scene;

    private Vector2 momentum;
    public static Vector2 momentumSeven;
    public GameObject player;

    PlayerMove playerMove;

    void Start()
    {
        Debug.Log(SM6to7.momentumSixEnd);

        playerMove = player.GetComponent<PlayerMove>();

        playerMove.controller.velocity = SM6to7.momentumSixEnd;
    }

    void Update()
    {
        momentum = playerMove.controller.velocity;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        momentumSeven = momentum * -1;
        //Debug.Log(momentum);

        SceneManager.LoadScene(scene);
    }
}
