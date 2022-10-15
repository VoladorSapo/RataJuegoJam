using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rat_movement : MonoBehaviour
{
    public rat_holes r_hole;
    Rigidbody2D rb_rat;
    public int speed;
    public int jumpforce;
    public float fall;
    public float gravity;
    public float slowdown;
    public float slowdownjump;
    public float moveAxis;
    public float acc_rate;
    public float decc_rate;
    public float movepow;
    public bool grounded;
    public KeyCode jump_key;
    public KeyCode action_key;
    public bool visible;
    public float PressTimeSet;
    public float PressTime;
    public float GroundTimeSet;
    public float GroundTime;
    public bool hidden;
    [SerializeField] LayerMask groundlayer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            slowdown = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            Die();
        }
    }
    void Start()
    {
        rb_rat = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(jump_key))
        {
            print("nooo");
            PressTime = PressTimeSet;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hidden)
        {
            moveAxis = Input.GetAxisRaw("Horizontal");
            float sptrg = speed * moveAxis;
            float spdf = sptrg - rb_rat.velocity.x;
            float rate = (Mathf.Abs(spdf) > 0.01) ? acc_rate : decc_rate;
            //float move = Mathf.Pow(Mathf.Abs(spdf) * rate , movepow) * Mathf.Sign(spdf);
            float move = spdf * rate;
            rb_rat.AddForce(Vector2.right * move * slowdown);
            grounded = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, groundlayer);
            //Mathf.max
            if (grounded && rb_rat.velocity.y <= 0.5)
            {
                GroundTime = GroundTimeSet;
            }
            if (PressTime > 0 && GroundTime > 0)
            {
                print("A" + rb_rat.velocity.y);
                rb_rat.velocity = new Vector2(rb_rat.velocity.x, 0);
                rb_rat.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
                slowdown = slowdownjump;
                GroundTime = 0;
                PressTime = 0;
            }
            if (rb_rat.velocity.y < 0)
            {
                rb_rat.gravityScale = gravity /** fall*/;
            }
            else
            {
                rb_rat.gravityScale = gravity;
            }
            GroundTime -= Time.deltaTime;
            PressTime -= Time.deltaTime;
        }
    }
    public void Die()
    {
        transform.position = new Vector3(-17, -3.5f, 0);
    }

}
