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

        // 플레이어 이동

        rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rb.velocity.y);

        if (Physics2D.Raycast(transform.position, Vector2.down,1.38f,groundCheck)&& Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
            anim.SetBool("Jump", true);
        }

        // 땅판정 확인선 그리기

        Debug.DrawRay(transform.position, Vector2.down * 1.38f);

        // 플레이어가 떨어지는 중인가?

        if (rb.velocity.y >= 0)
        {
            anim.SetBool("Fall", false);
        }

        else

        {
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", true);
        }

        // 플레이어 공격

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

        // 플레이어 시점 변환

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

        // 플레이어가 걷는 중인가?
        // Mathf.Abs = 절댓값

        anim.SetFloat("walkingSpeed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            anim.SetBool("walkingStart", true);
        }
        else
        {
            anim.SetBool("walkingStart", false);
        }
    }
}
