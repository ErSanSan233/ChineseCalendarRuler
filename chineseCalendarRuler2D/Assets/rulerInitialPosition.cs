using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rulerInitialPosition : MonoBehaviour
{
    public Transform xAxis;
    public Transform yAxis;
    [Range(0,2)]
    public float lineWidth = 1;
    public Transform rulerBaseSquare;
    public bool reverseY = false;

    protected Vector3 originPoint = new Vector3();
    protected Vector3 lineDeviation = new Vector3();
    protected Vector3 squareDeviation = new Vector3();

    public Vector3 o() {
        return originPoint + lineDeviation;
    }

    public Vector3 readyPosition() {
        return o() + squareDeviation;
    }

    void Start() {
        originPoint = new Vector3(
            yAxis.position.x,
            xAxis.position.y,
            0);

        lineDeviation = new Vector3(
            lineWidth / 2,
            (reverseY == true ? -1 : 1) * lineWidth / 2,
            0);

        squareDeviation = new Vector3(
            rulerBaseSquare.localScale.x/2,
            (reverseY == true ? -1 : 1) * rulerBaseSquare.localScale.y/2,
            0);

        transform.position = readyPosition();
    }

    void Update()
    {
        
    }
}
