using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rat_raycast : MonoBehaviour
{
    RaycastHit2D rc_down_left;
    RaycastHit2D rc_down_mid;
    RaycastHit2D rc_down_right;
    RaycastHit2D rc_right;
    RaycastHit2D rc_left;
    [SerializeField] LayerMask groundlayer;
    public bool grounded;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rc_down_mid = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, groundlayer);
        Debug.DrawRay(transform.position, Vector2.down, Color.blue);
        rc_down_right = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0), Vector2.down, 0.5f, groundlayer);
        Debug.DrawRay(transform.position + new Vector3(0.5f, 0), Vector2.down, Color.blue);
        rc_down_left = Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0), Vector2.down, 0.5f, groundlayer);
        Debug.DrawRay(transform.position + new Vector3(-0.5f, 0), Vector2.down, Color.blue);
        rc_right = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0), Vector2.right, 0.5f, groundlayer);
        Debug.DrawRay(transform.position + new Vector3(0.5f, 0), Vector2.right, Color.blue);
        rc_left = Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0), Vector2.left, 0.5f, groundlayer);
        Debug.DrawRay(transform.position + new Vector3(-0.5f, 0), Vector2.left, Color.blue);
        grounded = (rc_down_left || rc_down_mid || rc_down_right);
    }
}
