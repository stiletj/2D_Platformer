using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM2to3Lift : MonoBehaviour
{
    public string scene;

    private Vector2 momentum;
    public static Vector2 momentumTwoEndLift;
    public GameObject player;
    public Transform spawnPoint;

    PlayerMove playerMove;

    void Start()
    {
        //sm2to1 = twotoone.GetComponent<SM2to1>();

        if (SM3to2Lift.momentumThreeLift != new Vector2(0f, 0f))
        {
            player.transform.position = spawnPoint.position;
        }

        playerMove = player.GetComponent<PlayerMove>();

        playerMove.controller.velocity = SM3to2Lift.momentumThreeLift;

        SM3to2Lift.momentumThreeLift = new Vector2(0f, 0f);
    }

    void Update()
    {
        momentum = playerMove.controller.velocity;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        momentumTwoEndLift = momentum * 2;
        //Debug.Log(momentum);

        SceneManager.LoadScene(scene);
    }
}
