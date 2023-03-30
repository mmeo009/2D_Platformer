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

        // �÷��̾� �̵�

        rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rb.velocity.y);

        if (Physics2D.Raycast(transform.position, Vector2.down,1.38f,groundCheck)&& Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
            anim.SetBool("Jump", true);
        }

        // ������ Ȯ�μ� �׸���

        Debug.DrawRay(transform.position, Vector2.down * 1.38f);

        // �÷��̾ �������� ���ΰ�?

        if (rb.velocity.y >= 0)
        {
            anim.SetBool("Fall", false);
        }

        else

        {
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", true);
        }

        // �÷��̾� ����

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

        // �÷��̾� ���� ��ȯ

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

        // �÷��̾ �ȴ� ���ΰ�?
        // Mathf.Abs = ����

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
