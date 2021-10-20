using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveRuler : MonoBehaviour
{
    [Range(0, 30)]
    public float moveDistance = 0;

    void Start()
    {
        
    }


    void Update()
    {
        transform.position = GetComponent<rulerInitialPosition>().readyPosition() + new Vector3(moveDistance, 0, 0);
    }
}
