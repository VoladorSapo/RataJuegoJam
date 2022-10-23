using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rat_raycast : MonoBehaviour
{
    public rat_movement r_move;
    RaycastHit2D rc_down_left;
    RaycastHit2D rc_down_mid;
    RaycastHit2D rc_down_right;
    public RaycastHit2D rc_right_up;
    public RaycastHit2D rc_right_down;
    public RaycastHit2D rc_left_up;
    public RaycastHit2D rc_left_down;
    [SerializeField] LayerMask groundlayer;
    public bool grounded;
    public bool leftwall;
    public bool rightwall;
    public GameObject sprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rc_down_mid = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundlayer);
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
        rc_down_right = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0), Vector2.down,1f, groundlayer);
        Debug.DrawRay(transform.position + new Vector3(0.5f, 0), Vector2.down, Color.red);
        rc_down_left = Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0), Vector2.down, 1f, groundlayer);
        Debug.DrawRay(transform.position + new Vector3(-0.5f, 0), Vector2.down, Color.red);
        rc_right_up = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0.2f), Vector2.right, 0.5f, groundlayer);
        Debug.DrawRay(transform.position + new Vector3(0.5f, 0.2f), Vector2.right, Color.red);
        rc_right_down = Physics2D.Raycast(transform.position + new Vector3(0.5f, -0.2f), Vector2.right, 0.5f, groundlayer);
        Debug.DrawRay(transform.position + new Vector3(0.5f, -0.2f), Vector2.right, Color.red);
        rightwall = (rc_right_up||rc_right_down);
        rc_left_up = Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0.2f), Vector2.left, 0.5f, groundlayer);
        Debug.DrawRay(transform.position + new Vector3(-0.5f, 0.2f), Vector2.left, Color.red);
        rc_left_down = Physics2D.Raycast(transform.position + new Vector3(-0.5f, -0.2f), Vector2.left, 0.5f, groundlayer);
        Debug.DrawRay(transform.position + new Vector3(-0.5f, -0.2f), Vector2.left, Color.red);
        leftwall = (rc_left_up || rc_left_down); ;
        grounded = (rc_down_left || rc_down_mid || rc_down_right);
        if (rc_down_mid && Vector2.Angle(rc_down_mid.normal, Vector2.up) != 0)
        {
            r_move.onSlope = true;
        }
        else
        {
            r_move.onSlope = false;
        }
        r_move.slopeAngle = Vector2.Angle(rc_down_mid.normal, Vector2.up);
        if(rc_down_mid.normal.x > 0)
        {
            r_move.negativeslope = -1;
        }
        else
        {
            r_move.negativeslope = 1;
        }
        //sprite.transform.x
    }
}
