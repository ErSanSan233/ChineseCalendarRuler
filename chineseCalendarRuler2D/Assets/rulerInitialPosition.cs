using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rulerInitialPosition : MonoBehaviour
{
    public globalDefinitions def;

    
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
        originPoint = def.getO();

        lineDeviation = new Vector3(
            def.lineWidth/2,
            (reverseY == true ? -1 : 1) * def.lineWidth/2,
            0);

        squareDeviation = new Vector3(
            rulerBaseSquare.localScale.x/2,
            (reverseY == true ? -1 : 1) * rulerBaseSquare.localScale.y/2,
            0);

        //农历尺和中气轴思路不同：农历尺作为一个整体移动整个Transform，中气轴分散不动。
        //在突出显示闰月和当年范围时还是需要大打散并分别处理。
        transform.position = readyPosition();
    }

    void Update()
    {
        
    }
}
