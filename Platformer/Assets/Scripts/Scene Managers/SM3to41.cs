using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM3to41 : MonoBehaviour
{
    public string scene;

    private Vector2 momentum;
    public static Vector2 momentumThreeEndOne;
    public GameObject player;
    public Transform spawnPoint;

    PlayerMove playerMove;

    void Start()
    {
        //sm2to1 = twotoone.GetComponent<SM2to1>();

        if (SM4to31.momentumFourOne != new Vector2(0f, 0f))
        {
            player.transform.position = spawnPoint.position;
        }

        playerMove = player.GetComponent<PlayerMove>();

        playerMove.controller.velocity = SM4to31.momentumFourOne;

        SM4to31.momentumFourOne = new Vector2(0f, 0f);
    }

    void Update()
    {
        momentum = playerMove.controller.velocity;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        momentumThreeEndOne = momentum;
        //Debug.Log(momentum);

        SceneManager.LoadScene(scene);
    }
}
