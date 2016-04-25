using UnityEngine;
using System.Collections;

public class BinSenseBox : MonoBehaviour {
    SpriteRenderer sr;
    public int binColor;
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
    }
    void boxOver()
    {
        temp.SendMessage("checkColor", binColor);
    }
    void getPosition()
    {
        temp.SendMessage("acceptPosition", transform.position);
    }
    
}
