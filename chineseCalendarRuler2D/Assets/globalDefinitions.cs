using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalDefinitions : MonoBehaviour
{
    [Range(0,2)]
    public float lineWidth = 1;

    [SerializeField]
    private Transform xAxis;
    [SerializeField]
    private Transform yAxis;

    private static string[] months = {
        "腊\n月",
        "正\n月", "二\n月", "三\n月", 
        "四\n月", "五\n月", "六\n月",
        "七\n月", "八\n月", "九\n月",
        "十\n月", "冬\n月"
    };

    private static string[] zhongqi = {
        "大寒",
        "雨水", "春分", "谷雨", 
        "小满", "夏至", "大暑", 
        "处暑", "秋分", "霜降", 
        "小雪", "冬至"
    };

    // 此处按狭义节气，共12个，即不计入中气。
    // 广义节气即二十四节气，计入中气。
    private static string[] jieqi12 = {
        "小寒",
        "立春", "惊蛰", "清明", 
        "立夏", "芒种", "小暑", 
        "立秋", "白露", "寒露", 
        "立冬", "大雪",
    };

    private int modulo12(int _i){
        while(_i<=0){
            _i+=12;
        }

        return _i%12;
    }

    public Transform getXAxis(){
        return xAxis;
    }

    public Transform getYAxis(){
        return yAxis;
    }

    public Vector3 getO(){
        return new Vector3(
            yAxis.position.x,
            xAxis.position.y,
            0);
    }

    public string getMonth(int _month){
        return months[modulo12(_month)];
    }

    public string getJieqi12(int _month){
        return jieqi12[modulo12(_month)];
    }

    public string getZhongqi(int _month){
        return zhongqi[modulo12(_month)];
    }
}
