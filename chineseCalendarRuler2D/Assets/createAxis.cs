using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createAxis : MonoBehaviour{
    public globalDefinitions def;
    public Color yinColor = Color.black;
    public Color yangColor = Color.yellow;
    public GameObject pattern;
    public GameObject scaleRectangle;

    private ArrayList ruler = new ArrayList();

    //TODO untested
    public GameObject getRuler(int _index) {
        return (GameObject)ruler[_index];
    }

    void Start() {
        // 正月、二月是否置闰需再向前看2个月，若本年置闰则本年有13个月，故共需画出15个月。
        for (int i = -3; i < 15; i++) {
            GameObject _obj = GameObject.Instantiate(pattern);
            
            _obj.transform.position = scaleRectangle.transform.position
                + new Vector3(i * scaleRectangle.transform.localScale.x, 0, 0);

            _obj.GetComponent<SpriteRenderer>().enabled = false;
            _obj.transform.SetParent(transform);

            // 按国标，农历冬至所在月后第2个月（不计闰月）为农历年的第一个月
            _obj.GetComponentInChildren<TextMesh>().text = def.getZhongqi(i+1);
            ruler.Add(_obj);
        }

        pattern.SetActive(false);
        scaleRectangle.SetActive(false);
    }

    void Update()
    {
        
    }
}
