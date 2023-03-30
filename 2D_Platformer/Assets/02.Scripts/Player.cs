using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    RaycastHit2D hit;
    public Animator anim;
    public float moveSpeed = 5;
    public float jumpForce;
    public LayerMask groundCheck;
    public LayerMask monsterLayer;
    public bool isPlayerWatchingRight;
    public SpriteRenderer IMG;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        IMG = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 15;
            anim.SetBool("dash", true);
        }
        else
        {
            moveSpeed = 5;
            anim.SetBool("dash", false);
        }


        rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rb.velocity.y);

        if (Physics2D.Raycast(transform.position, Vector2.down,1.38f,groundCheck)&& Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.C))
        {
            if (Physics2D.Raycast(transform.position, Vector2.right, 2, monsterLayer)&& isPlayerWatchingRight)
                // Raycast(시작점, 방향, 거리, 검출할 레이어)
            {
                Debug.DrawRay(transform.position, Vector2.right * 2, Color.red);
            }

            if (Physics2D.Raycast(transform.position, Vector2.left, 2, monsterLayer)&& !isPlayerWatchingRight)
            {
                Debug.DrawRay(transform.position, Vector2.left * 2, Color.red);
            }
        }

        if (Input.GetAxis("Horizontal") > 0)
            // 축이 양수 일때 (오른쪽을 바라보고 있을때)
        {
            isPlayerWatchingRight = true;
            IMG.flipX = false;
        }

        if (Input.GetAxis("Horizontal") < 0)
            // 축이 음수일때 (왼쪽을 바라보고 있을때)
        {
            isPlayerWatchingRight = false;
            IMG.flipX = true;
        }
        Debug.DrawRay(transform.position, Vector2.down * 1.38f);
    }
}
