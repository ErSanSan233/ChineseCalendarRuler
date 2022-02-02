using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createRuler : MonoBehaviour{
    public globalDefinitions def;
    public GameObject basicRectangle;

    private int monthDelay = -2;
    private Vector3 rectanglePositionLag;

    List<GameObject> months = new List<GameObject>();

    public List<GameObject> getMonthsList() {
        return months;
    }

    public void resetMonthRuler() {
        for(int _i = 0; _i < months.Count; _i++) {
            months[_i].transform.position = basicRectangle.transform.position + 
                (_i + monthDelay) * rectanglePositionLag;
        }
    }

    public void drawLeapMonthRuler(int leapMonth) {
        resetMonthRuler();
        // 闰月后面的月份依次向后挪动一个身位，但颜色不变。
        if (leapMonth < months.Count) {
            for (int _i = leapMonth + 1; _i < months.Count; _i++) {
                months[_i].transform.position = months[_i].transform.position + rectanglePositionLag;
            }
        }
    }

    void Start() {
        // 锁定局部缩放：朔望月宽度固定，一定不要乱改
        transform.localScale = new Vector3(1, 1, 1);

        // 以参考矩形位置为标准绘制尺子，此后整体移动。故先确定参考矩形的相对位置为0
        // 正月、二月是否置闰需再向前看2个月，若本年置闰则本年有13个月，共需画出15个月
        basicRectangle.transform.position = transform.position;
        rectanglePositionLag = new Vector3(basicRectangle.transform.localScale.x, 0, 0);

        for (int _i = 0; _i < 15; _i++) {
            int i = _i +  monthDelay;

            GameObject _obj = GameObject.Instantiate(basicRectangle);

            _obj.transform.position = basicRectangle.transform.position +
                i * rectanglePositionLag;

            _obj.transform.SetParent(transform);

            _obj.GetComponent<SpriteRenderer>().color = i % 2 == 0 ? def.rulerYinColor : def.rulerYangColor;
            _obj.GetComponentInChildren<TextMesh>().color = i % 2 != 0 ? def.rulerYinColor : def.rulerYangColor;
            _obj.GetComponentInChildren<TextMesh>().text = def.getMonth(i+1);
            _obj.name = def.getMonth(i + 1).Remove(1, 1);

            
            months.Add(_obj);
        }
        basicRectangle.SetActive(false);

        // 闰月指示标记
    }


}
