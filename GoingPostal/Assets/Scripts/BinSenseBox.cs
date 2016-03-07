using UnityEngine;
using System.Collections;

public class BinSenseBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        Debug.Log(obj.name);
        obj.SendMessage("touchBin", transform.GetComponent<BoxCollider>());
    }
    
}
