using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM3to2Lift : MonoBehaviour
{
    public string scene;

    private Vector2 momentum;
    public static Vector2 momentumThreeLift;
    public GameObject player;
    public Transform spawnPoint;

    PlayerMove playerMove;

    void Start()
    {
        if (SM2to3Lift.momentumTwoEndLift != new Vector2(0f, 0f))
        {
            player.transform.position = spawnPoint.position;
        }

        Debug.Log(SM2to3Lift.momentumTwoEndLift);

        playerMove = player.GetComponent<PlayerMove>();

        playerMove.controller.velocity = SM2to3Lift.momentumTwoEndLift;

        SM2to3Lift.momentumTwoEndLift = new Vector2(0f, 0f);
    }

    void Update()
    {
        momentum = playerMove.controller.velocity;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        momentumThreeLift = momentum;
        //Debug.Log(momentum);

        SceneManager.LoadScene(scene);
    }
}
