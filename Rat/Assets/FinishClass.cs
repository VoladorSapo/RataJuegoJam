using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishClass : MonoBehaviour
{
    public static bool finished;
    // Start is called before the first frame update
    private void Awake()
    {
        finished = false;
        DontDestroyOnLoad(this);
    }
}
