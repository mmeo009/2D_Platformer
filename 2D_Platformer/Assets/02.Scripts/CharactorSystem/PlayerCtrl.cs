using UnityEngine;

public class PlayerCtrl : GeneralAnimation
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    public LayerMask Ground;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StatSetting(100, 10, 7, 10);
    }

    void Update()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * Stats.MoveSpeed, rb.velocity.y, 0);
        if (Input.GetAxis("Horizontal") != 0)
        {
            StateUpdate(CharacterStates.Run);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StateUpdate(CharacterStates.Jump);
            rb.velocity = Vector2.up * Stats.JumpForce;
        }
        if ((!Input.anyKeyDown || !Input.anyKey) && rb.velocity == Vector2.zero)
        {
            StateUpdate(CharacterStates.Idle);
        }

        if (rb.velocity.x != 0)
        {
            if (rb.velocity.x > 0)
            {
                sr.flipX = false;
            }
            if (rb.velocity.x < 0)
            {
                sr.flipX = true;
            }
        }
    }
}
