using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    public DashState dashState;
    public float dashTimer;
    public float maxDash = 2f;
    public GameObject player;
    public float dashSpeed = 2f;
    public float maxDashSpeed = 5f;
    //public float standingDashSpeed = 5f;
    public bool doingDash = false;

    private Rigidbody2D controller;
    private PlayerMove moveScript;
    private float direction = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Rigidbody2D>();
        moveScript = GetComponent<PlayerMove>();

        maxDashSpeed += moveScript.maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        switch (dashState)
        {
            case DashState.Ready:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (Input.GetButton("Horizontal"))
                    {
                        direction = Input.GetAxisRaw("Horizontal");
                    }

                    dashState = DashState.Dashing;
                }
                break;
            case DashState.Dashing:
                doingDash = true;
                dashTimer += Time.deltaTime * 10;

                if (controller.velocity.magnitude <= maxDashSpeed)
                {
                    if (direction >= 0)
                    {
                        controller.AddForce(new Vector2(dashSpeed, 0f));
                    }
                    else if (direction < 0)
                    {
                        controller.AddForce(new Vector2(-dashSpeed, 0f));
                    }
                }

                if (dashTimer >= maxDash)
                {
                    dashTimer = maxDash;
                    dashState = DashState.Cooldown;
                }
                break;
            case DashState.Cooldown:
                doingDash = false;
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = DashState.Ready;
                }
                break;
        }
    }

    public enum DashState
    {
        Ready,
        Dashing,
        Cooldown
    }
}
