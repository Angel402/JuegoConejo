using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float forceJump = 20f;
    public LayerMask groundLayerMask;
    public Animator animator;
    public GameObject spriteGO;
    public int bunnySpeed = 3;
    public static PlayerController sharedInstance;
    private Vector3 startPosition;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteGO = GameObject.Find("sprite");
        animator = spriteGO.GetComponent<Animator>();
        sharedInstance = this;
        animator.SetBool("isAlive", true);
        startPosition = transform.position;
    }

    public void StartGame()
    {
        rigidBody.velocity = new Vector2(0, 0);
        animator.SetBool("isAlive", true);
        transform.position = startPosition;
    }

    void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            if (IsOnTheFloor())
            {
                animator.SetBool("isGrounded", true);
                if (Input.GetKeyDown(KeyCode.W))
                {
                    Jump();
                }
            }
            else
            {
                animator.SetBool("isGrounded", false);
            }
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            if (rigidBody.velocity.x < bunnySpeed)
            {
                rigidBody.velocity = new Vector2(bunnySpeed, rigidBody.velocity.y);
            }
        }
    }

    void Jump()
    {
        rigidBody.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
    }

    bool IsOnTheFloor()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 1.0f, groundLayerMask.value))
        {
            return true;
        }else
        {
            return false;
        }
    }

    public void KillPlayer()
    {
        animator.SetBool("isAlive", false);
        GameManager.sharedInstance.GameOver();
    }

}
