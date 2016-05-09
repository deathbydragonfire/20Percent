using UnityEngine;
using System.Collections;

public class closeInfo : MonoBehaviour {

    public Texture closeTex;
	void OnGUI() {
        if (GUI.Button(new Rect(450, 290, 20, 20), closeTex, new GUIStyle()))
        {
            Camera.main.SendMessage("closeInfo");
            Destroy(gameObject);
        }
    }
}
