using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hole_paths : MonoBehaviour
{
    public GameObject[] holes;
    public HoleDirection[] holesdirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChangeHole(int hole_num)
    {
        holes[hole_num].GetComponentInChildren<Animator>().SetInteger("Agujero", 1);
        for (int i = 0; i < holes.Length; i++)
        {
            if (i != hole_num)
            {
                holes[i].GetComponentInChildren<Animator>().SetInteger("Agujero", 2);
            }
        }
    }
    public void LeaveHole()
    {
        for (int i = 0; i < holes.Length; i++)
        {
                holes[i].GetComponentInChildren<Animator>().SetInteger("Agujero", 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
