using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM6to7 : MonoBehaviour
{
    public string scene;

    private Vector2 momentum;
    public static Vector2 momentumSixEnd;
    public GameObject player;
    public Transform spawnPoint;

    PlayerMove playerMove;

    void Start()
    {
        //sm2to1 = twotoone.GetComponent<SM2to1>();

        if (SM7to6.momentumSeven != new Vector2(0f, 0f))
        {
            player.transform.position = spawnPoint.position;
        }

        playerMove = player.GetComponent<PlayerMove>();

        playerMove.controller.velocity = SM7to6.momentumSeven;

        SM7to6.momentumSeven = new Vector2(0f, 0f);
    }

    void Update()
    {
        momentum = playerMove.controller.velocity;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        momentumSixEnd = momentum;
        //Debug.Log(momentum);

        SceneManager.LoadScene(scene);
    }
}
