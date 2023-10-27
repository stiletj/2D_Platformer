using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SM4to31 : MonoBehaviour
{
    public string scene;

    private Vector2 momentum;
    public static Vector2 momentumFourOne;
    public GameObject player;
    public Transform spawnPoint;

    PlayerMove playerMove;

    void Start()
    {
        //sm1to2 = onetotwo.GetComponent<SM1to2>();

        if (SM3to41.momentumThreeEndOne != new Vector2(0f, 0f))
        {
            player.transform.position = spawnPoint.position;
        }

        playerMove = player.GetComponent<PlayerMove>();

        playerMove.controller.velocity = SM3to41.momentumThreeEndOne;

        SM3to41.momentumThreeEndOne = new Vector2(0f, 0f);
    }

    void Update()
    {
        momentum = playerMove.controller.velocity;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        momentumFourOne = momentum;
        //Debug.Log(momentum);

        SceneManager.LoadScene(scene);
    }
}
