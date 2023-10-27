using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    public DashState dashState;
    public float dashTimer;
    public float maxDash = 10f;
    public GameObject player;
    public float dashSpeed = 2;
    //public float standingDashSpeed = 5f;
    public bool doingDash = false;

    private Rigidbody2D controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (dashState)
        {
            case DashState.Ready:
                var isDashKeyDown = Input.GetKeyDown(KeyCode.Space);
                if (isDashKeyDown)
                {
                    /*if (controller.velocity.x != 0)
                    {
                        controller.velocity = new Vector2(controller.velocity.x * dashSpeed, 0f);
                        dashState = DashState.Dashing;
                    }
                    else
                    {
                        controller.velocity = new Vector2(controller.velocity.x + standingDashSpeed, 0f);
                        dashState = DashState.Dashing;
                    }*/
                    if (controller.velocity.x >= 0)
                    {
                        controller.velocity = new Vector2(controller.velocity.x + dashSpeed, 0f);
                        dashState = DashState.Dashing;
                    }
                    else if (controller.velocity.x < 0)
                    {
                        controller.velocity = new Vector2(controller.velocity.x - dashSpeed, 0f);
                        dashState = DashState.Dashing;
                    }
                }
                break;
            case DashState.Dashing:
                doingDash = true;
                dashTimer += Time.deltaTime * 10;
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
