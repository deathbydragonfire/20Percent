using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleButtons : MonoBehaviour {
    public Texture playTex;
    public Texture infoTex;
	void OnGUI() {
        if (GUI.Button(new Rect(450, 290, 50, 50), playTex, new GUIStyle())) {
            SceneManager.LoadScene("testScene");
        }
    }
}
