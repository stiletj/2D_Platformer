using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM8to7 : MonoBehaviour
{
    public string scene;

    private Vector2 momentum;
    public static Vector2 momentumEight;
    public GameObject player;

    PlayerMove playerMove;

    void Start()
    {
        Debug.Log(SM7to8.momentumSevenEnd);

        playerMove = player.GetComponent<PlayerMove>();

        playerMove.controller.velocity = SM7to8.momentumSevenEnd;
    }

    void Update()
    {
        momentum = playerMove.controller.velocity;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        momentumEight = momentum;
        //Debug.Log(momentum);

        SceneManager.LoadScene(scene);
    }
}
