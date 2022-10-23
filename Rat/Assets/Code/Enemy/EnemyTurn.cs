using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
    public float turnSeconds;
    private bool var =true;
    public void flip()
    {
        transform.Rotate(0, 180, 0);
        return;
    }
    IEnumerator turnAround()
    {
        var = false;
        yield return new WaitForSeconds(turnSeconds);
        flip();
        var = true;
    }



    // Update is called once per frame
   
void FixedUpdate()
    {
        if (var) { StartCoroutine(turnAround()); }
    }
}
