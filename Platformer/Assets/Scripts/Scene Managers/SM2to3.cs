using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM2to3 : MonoBehaviour
{
    public string scene;

    private Vector2 momentum;
    public static Vector2 momentumTwoEnd;
    public GameObject player;
    public Transform spawnPoint;

    PlayerMove playerMove;

    void Start()
    {
        //sm2to1 = twotoone.GetComponent<SM2to1>();

        if (SM3to2.momentumThree != new Vector2(0f, 0f))
        {
            player.transform.position = spawnPoint.position;
        }

        playerMove = player.GetComponent<PlayerMove>();

        playerMove.controller.velocity = SM3to2.momentumThree;

        SM3to2.momentumThree = new Vector2(0f, 0f);
    }

    void Update()
    {
        momentum = playerMove.controller.velocity;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        momentumTwoEnd = momentum;
        //Debug.Log(momentum);

        SceneManager.LoadScene(scene);
    }
}
