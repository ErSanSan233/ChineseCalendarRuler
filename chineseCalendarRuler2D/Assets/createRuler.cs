using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createRuler : MonoBehaviour{
    public Color yinColor = Color.black;
    public Color yangColor = Color.yellow;
    public GameObject basicRectangle;

    private ArrayList ruler = new ArrayList();
    void Start() {
        
        for (int i = 0; i < 13; i++) {
            GameObject _obj = GameObject.Instantiate(basicRectangle);
            _obj.transform.position = basicRectangle.transform.position
                + new Vector3(i * basicRectangle.transform.localScale.x, 0, 0);
            _obj.GetComponent<SpriteRenderer>().color = i % 2 == 0 ? yinColor : yangColor;
            _obj.transform.SetParent(transform);
            _obj.GetComponentInChildren<TextMesh>().text = "第" + (i + 1).ToString() + "月";
            _obj.GetComponentInChildren<TextMesh>().color = i % 2 != 0 ? yinColor : yangColor;
            ruler.Add(_obj);
        }

        basicRectangle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
