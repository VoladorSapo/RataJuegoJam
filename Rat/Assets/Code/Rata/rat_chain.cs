using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rat_chain : MonoBehaviour
{
    Rigidbody2D rb_rat;
    public rat_movement r_move;
    public bool canGrab; //Si esta tocando una cadena
    public GameObject chain;
    public KeyCode action_key;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cadena")
        {
            canGrab = true;
            chain = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cadena")
        {
            print("a");
            canGrab = false;
            chain = collision.gameObject;
            r_move.gravity = 4;
            r_move.Grabbed = false;
            rb_rat.velocity = new Vector2(rb_rat.velocity.x, rb_rat.velocity.y / 2);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb_rat = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(action_key) && canGrab)
        {
            r_move.gravity = 0;
            r_move.Grabbed = true;
            transform.position = new Vector2(chain.transform.position.x, transform.position.y);
        }
    }
}
