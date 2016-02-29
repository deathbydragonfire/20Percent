using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {
    SpriteRenderer sr;
    
   
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(255, 255, 255, 255);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            Vector3 pos = Input.GetTouch(0).position;
            Debug.Log("Touch " + pos);

            Ray ray = Camera.main.ScreenPointToRay(pos);
            if (Physics.Raycast(ray))
            {
                Debug.Log("Something hit");
                sr.color = new Color(100, 100, 100, 255);
            }

        }
	}
}
