using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM1to2 : MonoBehaviour
{
    public string scene;

    private Vector2 momentum;
    public static Vector2 momentumOneEnd;
    public GameObject player;
    public Transform spawnPoint;

    PlayerMove playerMove;

    void Start()
    {
        //sm2to1 = twotoone.GetComponent<SM2to1>();

        if (SM2to1.momentumTwo != new Vector2(0f, 0f))
        {
            player.transform.position = spawnPoint.position;
        }

        playerMove = player.GetComponent<PlayerMove>();

        playerMove.controller.velocity = SM2to1.momentumTwo;

        SM2to1.momentumTwo = new Vector2(0f, 0f);
    }

    void Update()
    {
        momentum = playerMove.controller.velocity;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        momentumOneEnd = momentum;
        //Debug.Log(momentum);

        SceneManager.LoadScene(scene);
    }
}
