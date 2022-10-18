using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform waypointsGO; // child y father 
    private Transform objective; // waypoint al que el enemigo va   
    private Transform[] waypoints; // array con todos los waypoints
    public float moveSpeed = 2f; // velocidad de movimiento 
    public int waypointIndex = 0; // index actual
    int direction; // 1 direccion de ida 0 de vuelta
    private bool enemyStop;
    public float waitSeconds;

    //
    private void Awake()
    {
        direction = 1;
        waypoints = new Transform[waypointsGO.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = waypointsGO.GetChild(i);
        }
    }
    // Use this for initialization
    private void Start()
    {
        direction = 1;
        objective = waypoints[1];
    }
    public void stopEnemy()
    {
        StartCoroutine(enemyStopCo());
    }
    IEnumerator enemyStopCo()
    {
        enemyStop = true;
        yield return new WaitForSeconds(waitSeconds);
        enemyStop = false;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 dir = objective.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
        if (!enemyStop) { transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World); }
        if (Vector2.Distance(transform.position, objective.position) <= 0.05f)
        {
            NextWayPoint();
        }
        if (waypoints.Length == waypointIndex - 1)
        {
            objective = waypoints[waypoints.Length - 1];
            direction = 0;
            waypointIndex = waypoints.Length - 1;
        }
        if (waypointIndex == -1)
        {
            objective = waypoints[1];
            direction = 1;
            waypointIndex = 1;
        }
    }
    private void NextWayPoint()
    {
        if (direction == 1)
        {
            waypointIndex++;
            if (waypointIndex - 1 != waypoints.Length)
            {
                objective = waypoints[waypointIndex];
            }

        }
        else if (direction == 0)
        {
            waypointIndex--;
            if (waypointIndex != -1)
            {
                objective = waypoints[waypointIndex];
            }
        }
    }
}
