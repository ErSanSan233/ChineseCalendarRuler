using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createRuler : MonoBehaviour{
    public globalDefinitions def;
    public Color yinColor;// = Color.black;
    public Color yangColor;// = Color.yellow;
    public Color leapRectangleColor = Color.yellow;
    public Color leapTextColor = Color.black;
    public GameObject basicRectangle;

    private ArrayList ruler = new ArrayList();
    
    //TODO untested
    public GameObject getRuler(int _index) {
        return (GameObject)ruler[_index];
    }

    void Start() {
        // 以参考矩形位置为标准绘制尺子，此后整体移动。故先确定参考矩形的相对位置为0
        basicRectangle.transform.position = transform.position;

        // 正月、二月是否置闰需再向前看2个月，若本年置闰则本年有13个月，共需画出15个月
        for (int i = -2; i < 12; i++) {
            GameObject _obj = GameObject.Instantiate(basicRectangle);
            _obj.transform.position = basicRectangle.transform.position
                + new Vector3(i * basicRectangle.transform.localScale.x, 0, 0);
            _obj.GetComponent<SpriteRenderer>().color = i % 2 == 0 ? yinColor : yangColor;
            _obj.transform.SetParent(transform);

            // 按国标，农历冬至所在月后第2个月（不计闰月）为农历年的第一个月
            _obj.GetComponentInChildren<TextMesh>().text = def.getMonth(i+1);
            _obj.GetComponentInChildren<TextMesh>().color = i % 2 != 0 ? yinColor : yangColor;
            ruler.Add(_obj);
        }

        basicRectangle.SetActive(false);
    }

    void Update()
    {
        
    }
}
