using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int moveSpeed = 5;
    public int jumpSpeed = 100;
    public int maxSpeed = 10;
    public GameObject player;
    public bool isGrounded = false;
    public bool multiCollide;

    public float forwardBack;
    public float jump;
    public float movement;
    public float jumping;
    public float speed;
    public double time = 0.2;

    public Rigidbody2D controller;
    private GameObject spawnPoint;
    private Dashing dashing;

    bool accelFrame = true;

    
    // Start is called before the first frame update
    void Start()
    {
        //spawnPoint = GameObject.Find("Spawn Point");

       // player.transform.position = spawnPoint.transform.position;

        controller = GetComponent<Rigidbody2D>();
        dashing = player.GetComponent<Dashing>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dashing.doingDash)
        {
            return;
        }

        speed = controller.velocity.magnitude;

        forwardBack = Input.GetAxisRaw("Horizontal");
        jump = Input.GetAxisRaw("Vertical");

        Vector3 scale = player.transform.localScale;

        if (Input.GetButton("Horizontal"))
        {
            if (accelFrame && Mathf.Abs(speed) <= maxSpeed)
            {
                controller.AddForce(new Vector2(forwardBack * moveSpeed, 0f));
            }

            movement = forwardBack * moveSpeed;

            accelFrame = !accelFrame;
        }

        if (Input.GetButtonDown("Vertical") && isGrounded == true && jump > 0)
        {
            Vector2 Jump = new Vector2(0f, jump * jumpSpeed);

            controller.AddForce(Jump);

            jumping = jump * jumpSpeed;

            isGrounded = false;
        }

       /* while (speed < 1 && Input.GetButtonDown(null))
        {
            speed = speed / 2;
            controller.velocity = new Vector2(speed, 0);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        multiCollide = false;
        if (isGrounded == true)
        {
            multiCollide = true;
        }
        else
        {
            isGrounded = true;
        }

        //Debug.Log("In");
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (multiCollide == false)
        {
            isGrounded = false;
        }

        //Debug.Log("Out");
    }
}
