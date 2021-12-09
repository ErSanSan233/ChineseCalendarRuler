using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leapCalculator : MonoBehaviour
{

    public globalDefinitions def;
    bool autoCalculation = false;

    private createRuler ruler;
    private createAxis axis;

    private List<float> zhongqiXList;
    private List<GameObject> monthList;

    public void ready() {
        zhongqiXList = axis.getZhongqiXList();
        monthList = ruler.getMonthsList();
    }

    public void calculate() {
        ready();
        int delay = -3;
        for (int _i = 0 + delay ; _i < monthList.Count + delay; _i++) {
            rectangleStateControl month =
                monthList[_i].GetComponent<rectangleStateControl>();
            //TODO 自动判定：新年、闰月
            // 自动设定格式
            // 手动可以设置更多新年相关事情
        }

        //foreach(GameObject month in monthList) {
  
        //    rectangleStateControl monthState = month.GetComponent<rectangleStateControl>();
        //    if (monthState.getIsLeap(zhongqiXList)) {
        //        monthState.setState(def.leapRectangleColor, def.leapTextColor);
        //    }

        //}
    }

    void Start()
    {
        ruler = def.ruler;
        axis = def.axis;
    }

    void Update()
    {
        
    }
}
