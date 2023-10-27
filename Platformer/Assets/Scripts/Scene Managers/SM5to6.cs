using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM5to6 : MonoBehaviour
{
    public string scene;

    private Vector2 momentum;
    public static Vector2 momentumFiveEnd;
    public GameObject player;
    public Transform spawnPoint;

    PlayerMove playerMove;

    void Start()
    {
        //sm2to1 = twotoone.GetComponent<SM2to1>();

        if (SM6to5.momentumSix != new Vector2(0f, 0f))
        {
            player.transform.position = spawnPoint.position;
        }

        playerMove = player.GetComponent<PlayerMove>();

        playerMove.controller.velocity = SM6to5.momentumSix;

        SM6to5.momentumSix = new Vector2(0f, 0f);
    }

    void Update()
    {
        momentum = playerMove.controller.velocity;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        momentumFiveEnd = momentum;
        //Debug.Log(momentum);

        SceneManager.LoadScene(scene);
    }
}
