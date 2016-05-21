using UnityEngine;
using System.Collections;

public class pauseButton : MonoBehaviour {
    bool paused = false;
    public Texture pauseTex;
	void OnGUI() {
        if (GUI.Button(new Rect(450, 15, 50, 50), pauseTex, new GUIStyle()))
        {
            if (paused)
            {
                paused = false;
                GameObject[] objects = (GameObject[])FindObjectsOfType(typeof(GameObject));
                for (int i = 0; i < objects.Length; i++ )
                {
                    objects[i].SendMessage("onResumeGame", SendMessageOptions.DontRequireReceiver);
                }
            }
            else
            {
                paused = true;
                GameObject[] objects = (GameObject[])FindObjectsOfType(typeof(GameObject));
                for (int i = 0; i < objects.Length; i++)
                {
                    objects[i].SendMessage("onPauseGame", SendMessageOptions.DontRequireReceiver);
                } 
            } 
            
       }
    }
}
