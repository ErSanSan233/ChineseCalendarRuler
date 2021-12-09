using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createRuler : MonoBehaviour{
    public globalDefinitions def;
    public GameObject basicRectangle;

    List<GameObject> months = new List<GameObject>();

    public List<GameObject> getMonthsList() {
        return months;
    }

    void Start() {
        transform.localScale = new Vector3(1, 1, 1);

        // 以参考矩形位置为标准绘制尺子，此后整体移动。故先确定参考矩形的相对位置为0
        basicRectangle.transform.position = transform.position;

        // 正月、二月是否置闰需再向前看2个月，若本年置闰则本年有13个月，共需画出15个月
        for (int i = -2; i < 13; i++) {
            GameObject _obj = GameObject.Instantiate(basicRectangle);
      
            _obj.transform.position = basicRectangle.transform.position
                + new Vector3(i * basicRectangle.transform.localScale.x, 0, 0);

            _obj.transform.SetParent(transform);

            _obj.GetComponent<SpriteRenderer>().color = i % 2 == 0 ? def.rulerYinColor : def.rulerYangColor;
            _obj.GetComponentInChildren<TextMesh>().color = i % 2 != 0 ? def.rulerYinColor : def.rulerYangColor;
            _obj.GetComponentInChildren<TextMesh>().text = def.getMonth(i+1);
            _obj.name = def.getMonth(i + 1).Remove(1, 1);

            
            months.Add(_obj);
        }
        basicRectangle.SetActive(false);
    }
}
