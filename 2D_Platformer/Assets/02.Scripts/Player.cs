using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    RaycastHit2D hit;
    float moveSpeed = 10;
    public float jumpForce;
    public LayerMask groundCheck;
    public LayerMask monsterLayer;
    public bool isPlayerWatchingRight;
    public SpriteRenderer IMG;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        IMG = GetComponent<SpriteRenderer>();

    }


    void Update()
    {
        rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rb.velocity.y);

        if (Physics2D.Raycast(transform.position, Vector2.down,1.38f,groundCheck)&& Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.C))
        {
            if (Physics2D.Raycast(transform.position, Vector2.right, 2, monsterLayer)&& isPlayerWatchingRight)
                // Raycast(������, ����, �Ÿ�, ������ ���̾�)
            {
                Debug.DrawRay(transform.position, Vector2.right * 2, Color.red);
            }

            if (Physics2D.Raycast(transform.position, Vector2.left, 2, monsterLayer)&& !isPlayerWatchingRight)
            {
                Debug.DrawRay(transform.position, Vector2.left * 2, Color.red);
            }
        }

        if (Input.GetAxis("Horizontal") > 0)
            // ���� ��� �϶� (�������� �ٶ󺸰� ������)
        {
            isPlayerWatchingRight = true;
            IMG.flipX = false;
        }

        if (Input.GetAxis("Horizontal") < 0)
            // ���� �����϶� (������ �ٶ󺸰� ������)
        {
            isPlayerWatchingRight = false;
            IMG.flipX = true;
        }
        Debug.DrawRay(transform.position, Vector2.down * 1.38f);
    }
}
