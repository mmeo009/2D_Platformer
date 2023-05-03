using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance; 
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    public AnimationClip AtkAnim;

    public float MoveSpeed = 5;
    public float jumpForce = 8;

    public bool attackAble = true;

    public short plrHead = 1;

    public LayerMask isGround;
    public LayerMask monsterLayer;


    //태현작품
    public int _hp;

    public int Hp
    {
        get
        {
            return _hp;
        }
        set
        {
            if (value < 0)
                value = 0;

            _hpBar.value = (float)value / _hpMax;
            _hp = value;
        }
    }
    [SerializeField] private Slider _hpBar;
    [SerializeField] private int _hpMax;
    //태현작품




    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C) && attackAble)
        {
            attackAble = false;
            rb.velocity = Vector3.zero;
            StartCoroutine(AtackTimer());
        }

        if (!attackAble)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Sliding", false);
        }

        if (attackAble)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed, rb.velocity.y);
            if (rb.velocity.x != 0)
            {
                if (rb.velocity.x > 0)
                {
                    plrHead = 1;
                    anim.SetBool("Run", true);
                    sr.flipX = false;
                }
                if (rb.velocity.x < 0)
                {
                    plrHead = -1;
                    anim.SetBool("Run", true);
                    sr.flipX = true;
                }
            }

            if (Physics2D.Raycast(transform.position, Vector2.down, 1.5f, isGround) && Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity += Vector2.up * jumpForce;

            }
            if (Input.GetButtonUp("Horizontal"))
            {
                anim.SetBool("Sliding", true);
            }
            if (rb.velocity.x == 0)
            {
                anim.SetBool("Run", false);
                anim.SetBool("Sliding", false);
            }
        }
    }

    IEnumerator AtackTimer()
    {
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(0.1f);
        float AtkSpeed = anim.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(AtkSpeed / 2);
        RaycastHit2D rayHitOBJ = Physics2D.Raycast(transform.position, Vector2.right * plrHead, 2, monsterLayer);

        if (rayHitOBJ.collider != null)
        {
            Debug.Log(rayHitOBJ.collider.name);
            rayHitOBJ.collider.GetComponent<Monster>().HP -= 10;
        }
        yield return new WaitForSeconds((AtkSpeed / 2) - 0.2f);
        if (rayHitOBJ.collider != null)
        {
            Debug.Log(rayHitOBJ.collider.name);
           rayHitOBJ.collider.GetComponent<Monster>().HP -= 10;
        }

        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Attack", false);
        attackAble = true;
    }
}
