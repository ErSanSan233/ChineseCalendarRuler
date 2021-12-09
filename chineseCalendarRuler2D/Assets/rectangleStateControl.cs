using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rectangleStateControl : MonoBehaviour
{
    //Unity中的位置判定很复杂，一会global一会local，有的还需要缩放
    //用一个cursor显示一下
    public enum cursorType {
        none,
        leftOnly,
        rightOnly,
        both
    }

    public cursorType showCursor = cursorType.none;
    public GameObject cursor;

    private SpriteRenderer rectangleSprite;
    private TextMesh textIndicator;    

    public bool getIsLeap(List<float> _zhongqiPositionXList) {
        foreach (float _zhongqiX in _zhongqiPositionXList){
            if (getLeftEdgeX() <= _zhongqiX && _zhongqiX < getRightEdgeX()) {
                return false;
            }
            else {
                
            }
        }
        return true;
    }

    // 有特殊规定某个月是否是闰月的情况，因此加一个强制闰月
    public bool getIsLeap(bool _forceLeap) {
        return _forceLeap;
    }

    public void setState(
        Color _rectangleColor,
        Color _textColor) {
        rectangleSprite.color = _rectangleColor;
        textIndicator.color = _textColor;
    }


    public void setState(
        Color _rectangleColor,
        Color _textColor,
        string _text) {
        setState(_rectangleColor, _textColor);
        textIndicator.text = _text;
    }


    float getLeftEdgeX() {
        return transform.position.x - transform.localScale.x / 2;
    }

    float getRightEdgeX() {
        return transform.position.x + transform.localScale.x / 2;
    }

    void Start()
    {
        rectangleSprite = GetComponent<SpriteRenderer>();
        textIndicator = GetComponentInChildren<TextMesh>();
    }

    void Update()
    {
        //visualization
        cursor.SetActive(!(showCursor==cursorType.none));
        switch (showCursor) {
            case cursorType.leftOnly:
                cursor.SetActive(true);
                cursor.transform.position = new Vector3(getLeftEdgeX(), transform.position.y, 0);
                break;
            case cursorType.rightOnly:
                cursor.SetActive(true);
                cursor.transform.position = new Vector3(getRightEdgeX(), transform.position.y, 0);
                break;
            case cursorType.both:
                cursor.SetActive(true);
                if (Time.time % 2 > 1) {
                    cursor.transform.position = new Vector3(getLeftEdgeX(), transform.position.y, 0);
                }
                else {
                    cursor.transform.position = new Vector3(getRightEdgeX(), transform.position.y, 0);
                }
                break;
            default: break;
        }
    }
}
