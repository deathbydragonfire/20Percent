using UnityEngine;
using System.Collections;

public class BinSenseBox : MonoBehaviour {
    SpriteRenderer sr;
    bool isOver = false;
    void Start()
    {
        GameObject go = transform.gameObject;
        sr = go.GetComponent<SpriteRenderer>();
        sr.color = new Color(255, 255, 255);
    }
    void Update()
    {
        if (isOver)
        {
            sr.color = new Color(152, 152, 152);
        }
        else
        {
            sr.color = new Color(255, 255, 255);
        }
    }
    void boxOver()
    {
        isOver = true;
    }
    
}
