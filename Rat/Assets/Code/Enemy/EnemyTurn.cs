using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
    public float turnSeconds;
    private bool var =true;
    public rat_movement r_move;
    public bool enemyDetection;
    public bool enemyKill;
    public float detectionSeconds;
    public GameObject player;
    Animator _anim;
    public SpriteRenderer exclamation;
    private void Start()
    {
        exclamation.enabled = false;
        _anim = GetComponent<Animator>();
    }
    public void flip()
    {
        transform.Rotate(0, 180, 0);
        return;
    }
    public IEnumerator enemyDetectionCo()
    {
        exclamation.enabled = true;
        enemyDetection = true;
        enemyKill = true;
        yield return new WaitForSeconds(detectionSeconds);
        IsKill();
        Debug.Log("a");
    }
    IEnumerator turnAround()
    {
        var = false;
        yield return new WaitForSeconds(turnSeconds);
        if (!enemyDetection)
        {
            flip();
        }
        var = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!r_move.hidden)
        {
            Debug.Log("detectado");
            StartCoroutine(enemyDetectionCo());
        }
    }
    private void IsKill()
    {
        if (enemyKill && !r_move.hidden)
        {
            Debug.Log("muerte");//morir
            player.GetComponent<rat_movement>().Die();
        }
        else
        {
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        exclamation.enabled = false;
        enemyDetection = false;
        enemyKill = false;
        StopCoroutine(enemyDetectionCo());
    }


    // Update is called once per frame

    void FixedUpdate()
    {
        if (var) { StartCoroutine(turnAround()); }
        if (r_move.hidden)
        {
            enemyDetection = false;
        }
    }
}
