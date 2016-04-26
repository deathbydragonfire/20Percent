using UnityEngine;
using System.Collections;

public class BinSenseBox : MonoBehaviour {
    SpriteRenderer sr;
    public int binColor;
    ArrayList boxes = new ArrayList();
    int count = 0;
    GameObject temp;

    void Start()
    {
        GameObject go = transform.gameObject;
        sr = go.GetComponent<SpriteRenderer>();
        sr.color = new Color(255, 255, 255);
    }
    void Update()
    {
        
            //sr.color = new Color(255, 255, 255);
        
    }
    void findBox(GameObject box)
    {
        
        temp = box;
        boxes.Add(temp);
        count++;
    }
    void boxOver()
    {
        print("boxOver");
        temp.SendMessage("checkColor", binColor);
    }
    void getBin()
    {
        temp.SendMessage("acceptBin", gameObject);
    }
    
}
