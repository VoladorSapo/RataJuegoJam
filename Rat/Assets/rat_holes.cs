using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rat_holes : MonoBehaviour
{
    public rat_movement r_move;
    public Vector2 hidenpos;
    public bool canHide;
    //public bool hidden;
    public hole_paths currentpaths;
    public int currenthole;
    Rigidbody2D rb_rat;
    public KeyCode action_key;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hole")
        {
            canHide = true;
            hidenpos = collision.transform.position;
            currentpaths = collision.GetComponentInParent<hole_paths>();
            currenthole = System.Array.IndexOf(currentpaths.holes, collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hole")
        {
            canHide = false;
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
        if (canHide && Input.GetKeyDown(action_key))
        {
            if (!r_move.hidden)
            {
                rb_rat.velocity = Vector2.zero;
                r_move.hidden = true;
                MoveHole(hidenpos);
                rb_rat.isKinematic = true;
            }
            else
            {
                rb_rat.isKinematic = false;
                r_move.hidden = false;
            }
        }
        if (r_move.hidden)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                if (currentpaths.holesdirection[currenthole].up >= 0)
                {

                    MoveHole(currentpaths.holes[currentpaths.holesdirection[currenthole].up].transform.position);
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                print("pito");
                if (currentpaths.holesdirection[currenthole].right >= 0)
                {
                    print("sus");
                    MoveHole(currentpaths.holes[currentpaths.holesdirection[currenthole].right].transform.position);
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                if (currentpaths.holesdirection[currenthole].down >= 0)
                {

                    MoveHole(currentpaths.holes[currentpaths.holesdirection[currenthole].down].transform.position);
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if (currentpaths.holesdirection[currenthole].left >= 0)
                {

                    MoveHole(currentpaths.holes[currentpaths.holesdirection[currenthole].left].transform.position);
                }
            }
        }
    }
    public void MoveHole(Vector2 pos)
    {
        transform.position = pos;
    }
}
