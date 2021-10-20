using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createRuler : MonoBehaviour{
    public Color yinColor = Color.black;
    public Color yangColor = Color.yellow;
    public GameObject basicRectangle;
    public string prefix = "第";

    private ArrayList ruler = new ArrayList();

    //TODO untested
    public GameObject getRuler(int _index) {
        return (GameObject)ruler[_index];
    }

    void Start() {
        for (int i = 0; i < 13; i++) {
            GameObject _obj = GameObject.Instantiate(basicRectangle);
            _obj.transform.position = basicRectangle.transform.position
                + new Vector3(i * basicRectangle.transform.localScale.x, 0, 0);
            _obj.GetComponent<SpriteRenderer>().color = i % 2 == 0 ? yinColor : yangColor;
            _obj.transform.SetParent(transform);
            _obj.GetComponentInChildren<TextMesh>().text = prefix + "\n" + (i + 1).ToString();
            _obj.GetComponentInChildren<TextMesh>().color = i % 2 != 0 ? yinColor : yangColor;
            ruler.Add(_obj);
        }

        basicRectangle.SetActive(false);
    }

    void Update()
    {
        
    }
}
