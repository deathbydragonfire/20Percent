using UnityEngine;
using System.Collections;

public class moveRight : MonoBehaviour {
	private float pos = -10;
	private float speed = 0.1f;
	private bool selected = false;
	// Use this for initialization
	void Start () {
		print(transform.position);

	}
	
	// Update is called once per frame
	void Update () {
		if ((pos < 10)&& (!selected)) {
			transform.position = new Vector2 (pos, -3.5f);
			pos += 0.1f;
			print (speed);
		}
	}
	public void select(bool yesNo) {
		selected = yesNo;
	}
}
