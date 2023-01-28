using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
    public float turnSeconds;
    public bool var =true;
    public rat_movement r_move;
    public bool enemyDetection;
    public bool enemyKill;
    public int detectionSeconds;
    public static bool ratDead;
    private void Awake()
    {
        ratDead = false;
    }
    public void flip()
    {
        transform.Rotate(0, 180, 0);
        return;
    }
    public IEnumerator enemyDetectionCo()
    {
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
        flip();
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
        if (enemyKill == true)
        {
            Debug.Log("muerte");//morir
            ratDead = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enemyDetection = false;
        enemyKill = false;
        StopCoroutine(enemyDetectionCo());
    }


    // Update is called once per frame

    void FixedUpdate()
    {
        if (var && !ratDead) { StartCoroutine(turnAround()); }
    }
}
