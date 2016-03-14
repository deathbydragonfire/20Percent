using UnityEngine;
using System.Collections;
using System.Threading;

public class SpawnBoxes : MonoBehaviour {
    public bool spawnActive = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int color = Random.Range(1, 5);
        int time = Random.Range(10, 100);
        Thread.Sleep(time);
        
	}
}
