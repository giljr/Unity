using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //hide the mouse cursor
        Cursor.visible = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        //make the mouse convas follows its position on screen 
        this.transform.position = Input.mousePosition;		
	}
}
