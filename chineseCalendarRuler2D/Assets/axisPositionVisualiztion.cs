using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axisPositionVisualiztion : MonoBehaviour
{

    public bool showCursor = false;
    public Transform cursor;

    public float getAxisPointX() {
        return transform.position.x - transform.localScale.x / 2;
    }

    void Update()
    {
        cursor.gameObject.SetActive(showCursor);
        if (showCursor) {
            cursor.position = new Vector3(getAxisPointX(), transform.position.y, 0);
        }
    }
}
